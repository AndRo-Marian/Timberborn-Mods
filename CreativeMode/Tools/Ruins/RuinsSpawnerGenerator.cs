using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.BlockSystem;
using Timberborn.ToolSystem;

namespace CreativeMode.Tools.Ruins
{
    public class RuinsSpawnerGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            string json = JsonConvert.SerializeObject(new
            {
                Id = "Test2",
                GroupId = "RuinsSpawner",
                Type = "Ruin",
                Layout = "Default",
                Order = 1,
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                NameLocKey = "CAN NOT BE MODIFIED",
                DescriptionLocKey = "CAN NOT BE MODIFIED",
                Hidden = false,
                DevMode = false,
                ToolInformation = new
                {
                }
            });
            yield return new GeneratedSpecification(json, "Test2", "ToolSpecification");
            
            yield return new GeneratedSpecification(JsonConvert.SerializeObject(new
            {
                Id = "RuinsSpawner",
                GroupId = "CreativeMode",
                Layout = "Green",
                Order = 3,
                Type = "DefaultToolGroup",
                NameLocKey = "CreativeMode.ToolGroups",
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            }), "RuinsSpawner", "ToolGroupSpecification");
        }
    }
}