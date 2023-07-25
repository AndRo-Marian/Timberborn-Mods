using Bindito.Core;
using Bindito.Unity;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;
using TimberApi.SpecificationSystem;
using Timberborn.BuildingRange;
using Timberborn.Emptying;
using Timberborn.Hauling;
using Timberborn.LaborSystem;
using Timberborn.ReservableSystem;
using Timberborn.Ruins;
using Timberborn.SimpleOutputBuildings;
using Timberborn.SoilMoistureSystem;
using Timberborn.TemplateSystem;
using Timberborn.WorkSystem;

namespace CreativeMode.Tools.Ruins
{
    [Configurator(SceneEntrypoint.InGame)]
    public class RuinsSpawnerConfigurator : PrefabConfigurator
    {
        private class TemplateModuleProvider : IProvider<TemplateModule>
        {
            public TemplateModule Get()
            {
                TemplateModule.Builder builder = new TemplateModule.Builder();
                builder.AddDecorator<Ruin, AccessibleReservableDestinationProvider>();
                builder.AddDecorator<Ruin, RuinModels>();
                builder.AddDecorator<Ruin, RuinModelUpdater>();
                builder.AddDecorator<Ruin, DryObject>();
                builder.AddDecorator<Scavenger, BuildingWithTerrainRange>();
                builder.AddDecorator<Scavenger, AutoEmptiable>();
                builder.AddDecorator<Scavenger, Emptiable>();
                builder.AddDecorator<Scavenger, HaulCandidate>();
                builder.AddDecorator<Scavenger, SimpleOutputInventoryHaulBehaviorProvider>();
                builder.AddDecorator<Scavenger, ScavengerYielderRetriever>();
                AddDecoratingBehaviors(builder);
                return builder.Build();
            }

            private static void AddDecoratingBehaviors(TemplateModule.Builder builder)
            {
                builder.AddDecorator<Scavenger, RemoveUnwantedStockWorkplaceBehavior>();
                builder.AddDecorator<Scavenger, ScavengerWorkplaceBehavior>();
                builder.AddDecorator<Scavenger, EmptyOutputWorkplaceBehavior>();
                builder.AddDecorator<Scavenger, EmptyInventoriesWorkplaceBehavior>();
                builder.AddDecorator<Scavenger, LaborWorkplaceBehavior>();
                builder.AddDecorator<Scavenger, WaitInsideIdlyWorkplaceBehavior>();
            }
        }
        
        public override void Configure(IContainerDefinition containerDefinition)
        {
            //containerDefinition.Bind<RuinModelFactory>().ToInstance(GetInstanceFromPrefab<RuinModelFactory>());
            //containerDefinition.MultiBind<TemplateModule>().ToProvider<TemplateModuleProvider>().AsSingleton();
            
            containerDefinition.MultiBind<ISpecificationGenerator>().To<RuinsSpawnerGenerator>().AsSingleton();
        }
    }
}