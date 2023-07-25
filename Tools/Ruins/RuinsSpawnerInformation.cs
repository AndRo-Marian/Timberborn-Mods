using System;
using Timberborn.PrioritySystem;

namespace CreativeMode.Tools.Ruins
{
    public class RuinsSpawnerInformation
    {
        public Priority Priority { get; }

        public RuinsSpawnerInformation(string priority)
        {
            if (Enum.TryParse<Priority>(priority, out var result))
            {
                Priority = result;
                return;
            }
            Priority = Priority.Normal;
        }
    }
}