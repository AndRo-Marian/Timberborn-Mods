using TimberApi.ToolSystem;
using Timberborn.Persistence;
using Timberborn.ToolSystem;

namespace CreativeMode.Tools.Ruins
{
    public class RuinsSpawnerFactory : BaseToolFactory<RuinsSpawnerInformation>
    {
        private readonly Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory _builderPriorityToolFactory;

        public override string Id => "PriorityTool";

        public RuinsSpawnerFactory(Timberborn.BuilderPrioritySystemUI.BuilderPriorityToolFactory builderPriorityToolFactory)
        {
            _builderPriorityToolFactory = builderPriorityToolFactory;
        }

        protected override Tool CreateTool(ToolSpecification toolSpecification, RuinsSpawnerInformation toolInformation, ToolGroup toolGroup)
        {
            return _builderPriorityToolFactory.Create(toolInformation.Priority);
        }

        protected override RuinsSpawnerInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new RuinsSpawnerInformation(objectLoader.Get(new PropertyKey<string>("Priority")));
        }
    }
}