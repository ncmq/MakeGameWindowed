using HarmonyLib;
using MakeGameWindowed.Important;


namespace MakeGameWindowed.Important.Patching.Patches
{
    [HarmonyPatch(typeof(Plugin))]
    [HarmonyPatch("OnGameInitialized", MethodType.Normal)]
    internal class ExamplePatch
    {
        private static void Postfix()
        {
            Logs.Log("Game initialization complete!");
        }
    }
}
