using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.ToolSystem;
using Timberborn.MapEditor;
using Timberborn.ToolPanelSystem;

namespace CreativeMode.Tools.MapEditor
{
	[Configurator(SceneEntrypoint.InGame)]
    public class MapEditConfigurator : IConfigurator
	{
        public void Configure(IContainerDefinition containerDefinition)
        {
	        containerDefinition.Bind<MapEditorButtons>().AsSingleton();
	        containerDefinition.Bind<AbsoluteTerrainHeightTool>().AsSingleton();

	        containerDefinition.Bind<NaturalResourceLayerService>().AsSingleton();
	        containerDefinition.Bind<BrushProbabilityMap>().AsSingleton();
	        containerDefinition.Bind<BrushShapeIterator>().AsSingleton();
	        containerDefinition.Bind<NaturalResourceSpawner>().AsSingleton();
	        containerDefinition.Bind<NoStartingLocationAlertFragment>().AsSingleton();
	        containerDefinition.Bind<BrushHeightPanel>().AsSingleton();
	        containerDefinition.Bind<BrushSizePanel>().AsSingleton();
	        containerDefinition.Bind<BrushShapePanel>().AsSingleton();
	        containerDefinition.Bind<NaturalResourceSpawningBrushPanel>().AsSingleton();
	        
	        containerDefinition.Bind<AbsoluteTerrainHeightBrushTool>().AsSingleton();
	        containerDefinition.Bind<RelativeTerrainHeightBrushTool>().AsSingleton();
	        containerDefinition.Bind<NaturalResourceSpawningBrushTool>().AsSingleton();
	        containerDefinition.Bind<NaturalResourceRemovalBrushTool>().AsSingleton();
	        
	        containerDefinition.Bind<NaturalResourceLayerToggle>().AsSingleton();
	        containerDefinition.MultiBind<ToolPanelModule>().ToProvider<MapEditorConfigurator.ToolPanelModuleProvider>().AsSingleton();
	        containerDefinition.MultiBind<IToolFactory>().To<AbsoluteTerrainHeightToolFactory>().AsSingleton();
	        
            containerDefinition.Bind<MapEditGenerator>().AsSingleton();
            /*containerDefinition.Bind<MapEditorButtons>().AsSingleton();

            containerDefinition.Bind<NaturalResourceLayerService>().AsSingleton();
            containerDefinition.Bind<BrushProbabilityMap>().AsSingleton();
            containerDefinition.Bind<BrushShapeIterator>().AsSingleton();
            containerDefinition.Bind<NaturalResourceSpawner>().AsSingleton();
            containerDefinition.Bind<NoStartingLocationAlertFragment>().AsSingleton();
            containerDefinition.Bind<BrushHeightPanel>().AsSingleton();
            containerDefinition.Bind<BrushSizePanel>().AsSingleton();
            containerDefinition.Bind<BrushShapePanel>().AsSingleton();
            containerDefinition.Bind<NaturalResourceSpawningBrushPanel>().AsSingleton();
            containerDefinition.Bind<AbsoluteTerrainHeightBrushTool>().AsSingleton();
            containerDefinition.Bind<RelativeTerrainHeightBrushTool>().AsSingleton();
            containerDefinition.Bind<NaturalResourceSpawningBrushTool>().AsSingleton();
            containerDefinition.Bind<NaturalResourceRemovalBrushTool>().AsSingleton();
            containerDefinition.Bind<NaturalResourceLayerToggle>().AsSingleton();
            containerDefinition.MultiBind<ToolPanelModule>().ToProvider<ToolPanelModuleProvider>().AsSingleton();*/
        }
	}
}