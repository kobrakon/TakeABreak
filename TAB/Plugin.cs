using BepInEx;
using UnityEngine;
using BepInEx.Configuration;

namespace TAB
{
    [BepInPlugin("com.kobrakon.TAB", "TAB", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static GameObject Hook;
        const string KeybindSectionName = "Keybinds";
        internal static ConfigEntry<KeyboardShortcut> TogglePause;
        void Awake()
        {
            TogglePause = Config.Bind(KeybindSectionName, "Toggle Pause", new KeyboardShortcut(KeyCode.P));
            Logger.LogInfo($"TAB: Loading");
            new WorldTickPatch().Enable();
            new OtherWorldTickPatch().Enable();
            Hook = new GameObject("TAB");
            Hook.AddComponent<TABController>();
            DontDestroyOnLoad(Hook);
        }
    }
}