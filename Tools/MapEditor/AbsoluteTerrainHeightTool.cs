using System.Collections.Generic;
using System.Linq;
using Timberborn.BlockSystem;
using Timberborn.CameraSystem;
using Timberborn.Common;
using Timberborn.Core;
using Timberborn.InputSystem;
using Timberborn.Localization;
using Timberborn.MapEditor;
using Timberborn.Rendering;
using Timberborn.SingletonSystem;
using Timberborn.TerrainSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace CreativeMode.Tools.MapEditor
{
    public class AbsoluteTerrainHeightTool : Tool, IInputProcessor, ILoadableSingleton, IBrushWithSize, IBrushWithShape, IBrushWithHeight
	{
		private static readonly string TitleLocKey = "MapEditor.Brush.AbsoluteTerrainHeight";
		private static readonly float MarkerYOffset = 0.02f;
		private static readonly Color NeutralTileColor = new Color(0.8f, 0.8f, 0.8f, 0.5f);
		private static readonly Color PositiveTileColor = new Color(0f, 1f, 0f, 0.7f);
		private static readonly Color NegativeTileColor = new Color(1f, 0f, 0f, 0.7f);
		private readonly InputService _inputService;
		private readonly ITerrainService _terrainService;
		private readonly BrushShapeIterator _brushShapeIterator;
		private readonly BlockService _blockService;
		private readonly TerrainPicker _terrainPicker;
		private readonly CameraComponent _cameraComponent;
		private readonly MarkerDrawerFactory _markerDrawerFactory;
		private readonly ILoc _loc;
		private MeshDrawer _meshDrawer;
		private ToolDescription _toolDescription;
		private bool _drawing;
		private Vector3Int _drawingStartCoordinates;
		public int BrushSize { get; set; } = 3;
		public int BrushHeight { get; set; } = 1;
		public BrushShape BrushShape { get; set; }
		public int MinimumBrushHeight => 0;

		public AbsoluteTerrainHeightTool(InputService inputService, ITerrainService terrainService, BrushShapeIterator brushShapeIterator, BlockService blockService, TerrainPicker terrainPicker, CameraComponent cameraComponent, MarkerDrawerFactory markerDrawerFactory, ILoc loc)
		{
			_inputService = inputService;
			_terrainService = terrainService;
			_brushShapeIterator = brushShapeIterator;
			_blockService = blockService;
			_terrainPicker = terrainPicker;
			_cameraComponent = cameraComponent;
			_markerDrawerFactory = markerDrawerFactory;
			_loc = loc;
		}

		public void Load()
		{
			InitializeToolDescription();
			_meshDrawer = _markerDrawerFactory.CreateTileDrawer();
		}

		public bool ProcessInput()
		{
			ProcessBrush();
			return false;
		}

		public override void Enter()
		{
			_inputService.AddInputProcessor(this);
		}

		public override void Exit()
		{
			_inputService.RemoveInputProcessor(this);
		}

		public override ToolDescription Description()
		{
			return _toolDescription;
		}

		private void ProcessBrush()
		{
			Ray ray = _cameraComponent.ScreenPointToRayInGridSpace(_inputService.MousePosition);
			if (!_drawing)
			{
				if (_inputService.PrimaryBrush && !_inputService.MouseOverUI)
				{
					TraversedCoordinates? traversedCoordinates = _terrainPicker.PickTerrainCoordinates(ray);
					if (traversedCoordinates.HasValue)
					{
						TraversedCoordinates valueOrDefault = traversedCoordinates.GetValueOrDefault();
						_drawing = true;
						_drawingStartCoordinates = valueOrDefault.Coordinates + valueOrDefault.Face;
					}
				}
			}
			else if (!_inputService.PrimaryBrushHeld)
			{
				_drawing = false;
			}
			if (_drawing)
			{
				ApplyBrush(ray, _drawingStartCoordinates.z);
			}
			else
			{
				PreviewBrush(ray);
			}
		}

		private void ApplyBrush(Ray ray, int referenceHeight)
		{
			Vector3Int? vector3Int = _terrainPicker.FindCoordinatesOnLevelInMap(ray, referenceHeight);
			if (!vector3Int.HasValue)
			{
				return;
			}
			Vector3Int valueOrDefault = vector3Int.GetValueOrDefault();
			foreach (Vector2Int affectedCoordinate in GetAffectedCoordinates(valueOrDefault.XY()))
			{
				_terrainService.SetHeight(affectedCoordinate, BrushHeight);
			}
			DrawTileMarkers(valueOrDefault);
		}

		private void PreviewBrush(Ray ray)
		{
			TraversedCoordinates? traversedCoordinates = _terrainPicker.PickTerrainCoordinates(ray);
			if (traversedCoordinates.HasValue)
			{
				TraversedCoordinates valueOrDefault = traversedCoordinates.GetValueOrDefault();
				Vector3Int center = valueOrDefault.Coordinates + valueOrDefault.Face;
				DrawTileMarkers(center);
			}
		}

		private void InitializeToolDescription()
		{
			_toolDescription = new ToolDescription.Builder(_loc.T(TitleLocKey)).Build();
		}

		private IEnumerable<Vector2Int> GetAffectedCoordinates(Vector2Int center)
		{
			return from coords2D in _brushShapeIterator.IterateShape(center, BrushSize, BrushShape)
				where !_blockService.AnyObjectAtColumn(coords2D)
				select coords2D;
		}

		private void DrawTileMarkers(Vector3Int center)
		{
			foreach (Vector2Int affectedCoordinate in GetAffectedCoordinates(center.XY()))
			{
				int num = _terrainService.CellHeight(affectedCoordinate);
				Vector3Int coordinates = new Vector3Int(affectedCoordinate.x, affectedCoordinate.y, num);
				int num2 = BrushHeight - num;
				Color color = ((num2 == 0) ? NeutralTileColor : ((num2 > 0) ? PositiveTileColor : NegativeTileColor));
				_meshDrawer.DrawAtCoordinates(coordinates, MarkerYOffset, color);
			}
		}
	}
}