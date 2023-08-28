using EFT;
using System.Reflection;
using Aki.Reflection.Patching;

namespace TAB
{
    public class WorldTickPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(GameWorld).GetMethod("DoWorldTick", BindingFlags.Instance | BindingFlags.Public);

        [PatchPrefix]
        static bool Prefix() => !TABController.m_isPaused;
    }

    public class OtherWorldTickPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() => typeof(GameWorld).GetMethod("DoOtherWorldTick", BindingFlags.Instance | BindingFlags.Public);

        [PatchPrefix]
        static bool Prefix() => !TABController.m_isPaused;
    }
}