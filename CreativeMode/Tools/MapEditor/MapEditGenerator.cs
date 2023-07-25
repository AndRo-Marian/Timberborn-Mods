using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;

namespace CreativeMode.Tools.MapEditor
{
    public class MapEditGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            yield return new GeneratedSpecification(JsonConvert.SerializeObject(new
            {
                Id = "TestId",
                GroupId = "CreativeMode",
                Type = "AbsoluteTerrainHeightTool",
                Layout = "Default",
                Order = 3,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/BotGeneratorTool",
                DevMode = false,
                Hidden = false
            }), "TestId", "ToolSpecification");
            yield return new GeneratedSpecification(JsonConvert.SerializeObject(new
            {
                Id = "TestId2",
                GroupId = "CreativeMode",
                Type = "RelativeTerrainHeightBrushTool",
                Layout = "Default",
                Order = 4,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/BotGeneratorTool",
                DevMode = false,
                Hidden = false
            }), "TestId2", "ToolSpecification");
            yield return new GeneratedSpecification(JsonConvert.SerializeObject(new
            {
                Id = "TestId3",
                GroupId = "CreativeMode",
                Type = "NaturalResourceSpawningBrushTool",
                Layout = "Default",
                Order = 5,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/BotGeneratorTool",
                DevMode = false,
                Hidden = false
            }), "TestId3", "ToolSpecification");
            yield return new GeneratedSpecification(JsonConvert.SerializeObject(new
            {
                Id = "TestId4",
                GroupId = "CreativeMode",
                Type = "NaturalResourceRemovalBrushTool",
                Layout = "Default",
                Order = 6,
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Icon = "Sprites/BottomBar/BotGeneratorTool",
                DevMode = false,
                Hidden = false
            }), "TestId4", "ToolSpecification");
        }
    }
}