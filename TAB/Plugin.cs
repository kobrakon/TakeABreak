using BepInEx;
using UnityEngine;
using BepInEx.Configuration;

namespace TAB
{
    [BepInPlugin("com.kobrakon.TAB", "TAB", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static GameObject Hook;
        private const string KeybindSectionName = "Keybinds";
        internal static ConfigEntry<KeyboardShortcut> TogglePause;
        private void Awake()
        {
            TogglePause = Config.Bind(KeybindSectionName, "Toggle Pause", new KeyboardShortcut(KeyCode.P));
            Logger.LogInfo($"TAB: Loading");
            Hook = new GameObject("TAB");
            Hook.AddComponent<TABController>();
            DontDestroyOnLoad(Hook);
        }
    }
}