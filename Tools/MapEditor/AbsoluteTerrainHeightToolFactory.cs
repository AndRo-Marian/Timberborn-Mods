using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace CreativeMode.Tools.MapEditor
{
    public class AbsoluteTerrainHeightToolFactory : IToolFactory
    {
        public string Id => "AbsoluteTerrainHeightTool";
        private readonly AbsoluteTerrainHeightTool _absoluteTerrainHeightTool;

        public AbsoluteTerrainHeightToolFactory(AbsoluteTerrainHeightTool absoluteTerrainHeightTool)
        {
            _absoluteTerrainHeightTool = absoluteTerrainHeightTool;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _absoluteTerrainHeightTool.Load();
            
            return _absoluteTerrainHeightTool;
        }
    }
}