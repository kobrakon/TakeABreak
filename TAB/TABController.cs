using Comfort.Common;
using EFT;
using UnityEngine;

namespace TAB
{
    public class TABController : MonoBehaviour
    {
       public static bool isPaused { get; private set; } = false;
       public void Update()
       {
            if (Plugin.TogglePause.Value.IsDown())
            {
                if (IsGameReady())
                {
                    if (!isPaused)
                    {
                        Time.timeScale = 0;
                        isPaused = true;
                        return;
                    }
                    else
                        isPaused = !isPaused;
                        Time.timeScale = 1;
                    return;
                }
                return;
            }
       }

       bool IsGameReady()
       {
            var gameWorld = Singleton<GameWorld>.Instance;
            
            if (gameWorld == null || gameWorld.AllPlayers[0] is HideoutPlayer)
            {
                if (isPaused) isPaused = !isPaused;
                return false;
            }
            return true;
       }
    }
}