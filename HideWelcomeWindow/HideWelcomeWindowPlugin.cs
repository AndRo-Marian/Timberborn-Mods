using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;
using Timberborn.MainMenuScene;

namespace HideWelcomeWindow
{
    [HarmonyPatch]
    public class HideWelcomeWindowPlugin : IModEntrypoint
    {
        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            var harmony = new Harmony("com.github.andro-marian.hidewelcomewindow");
            
            harmony.PatchAll();
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(WelcomeScreenBox), "Show")]
        public static bool OnWelcomeScreenShow(WelcomeScreenBox __instance)
        {
            __instance.ShowMainMenu();
            return false;
        }

    }
}
