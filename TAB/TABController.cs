using EFT;
using UnityEngine;
using Comfort.Common;

namespace TAB
{
    public class TABController : MonoBehaviour
    {
       internal static bool isPaused { get; private set; } = false;
       
       void Update()
       {
            if (IsGameReady())
            {
                if (Input.GetKeyDown(Plugin.TogglePause.Value.MainKey))
                    isPaused = !isPaused;

                if (isPaused && Time.timeScale == 1f)
                {
                    Time.timeScale = 0f;
                    player.HandsAnimator.SetAnimationSpeed(0f);
                    return;
                }

                if (!isPaused && Time.timeScale != 1f)
                    player.HandsAnimator.SetAnimationSpeed(1f);
                    Time.timeScale = 1f;
                return;

            } else if (isPaused) isPaused = false;
       }

       bool IsGameReady() => gameWorld != null && gameWorld.AllPlayers != null && gameWorld.AllPlayers.Count > 0 && player != null;
       GameWorld gameWorld { get => Singleton<GameWorld>.Instance; }
       Player player { get => gameWorld.AllPlayers[0]; }
    }
}