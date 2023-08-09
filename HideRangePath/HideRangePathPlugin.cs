using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.DependencyContainerSystem;
using TimberApi.ModSystem;
using Timberborn.BuildingsNavigation;
using Timberborn.GameScene;
using Timberborn.InputSystem;

namespace HideRangePath
{
    [HarmonyPatch]
    public class HideRangePathPlugin : IModEntrypoint
    {
        private static InputService _key;
        
        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            var harmony = new Harmony("com.github.andro-marian.hiderangepath");
            
            harmony.PatchAll();
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(NewGameInitializer), "Start")]
        private static void OnGameStarted(NewGameInitializer __instance)
        {
            _key = DependencyContainer.GetInstance<InputService>();
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(BuildingRangeDrawer), "OnSelect")]
        public static bool OnBuildingSelect(BuildingRangeDrawer __instance)
        {
            if (_key.IsShiftHeld)
            {
                __instance.DrawRange();
                __instance.enabled = true;
            }
            return false;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(BuildingRangeDrawer), "OnPreviewSelect")]
        public static bool OnBuildingPreviewSelect(BuildingRangeDrawer __instance)
        {
            __instance.enabled = _key.IsShiftHeld;
            return false;
        }
    }
}
