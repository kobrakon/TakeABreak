using EFT;
using System;
using UnityEngine;
using Comfort.Common;
using System.Reflection;

namespace TAB
{
    public class TABController : MonoBehaviour
    {
       internal static bool m_isPaused = false;
       internal bool isPaused
        {
            get => m_isPaused;
            set
            {
                if (IsGameReady())
                {
                    m_isPaused = value;

                    Time.timeScale = value ? 0f : 1f;
                    try
                    {
                        player.HandsAnimator.SetAnimationSpeed(value ? 0f : 1f);
                    } catch (Exception)
                    {
                        return;
                    }

                    if (value)
                        SessionTimer.Stop();
                    else
                    {
                        try
                        {
                            var seshTime = SessionTimer.SessionTime;
                            typeof(GameTimerClass).GetField("nullable_0", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(SessionTimer, null);
                            typeof(GameTimerClass).GetField("nullable_2", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(SessionTimer, null);
                            typeof(GameTimerClass).GetField("nullable_3", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(SessionTimer, null);
                            SessionTimer.Start(SessionTimer.StartDateTime, seshTime - SessionTimer.PastTime);
                        } catch (Exception) { }
                    }

                    return;
                }
                Time.timeScale = !(m_isPaused = false) ? 1f:1f;
            }
        }
       
       void Update()
       {
            if (IsGameReady())
            {
                if (Input.GetKeyDown(Plugin.TogglePause.Value.MainKey))
                    isPaused = !isPaused;
                return;
            }
            if (isPaused) isPaused = false;
       }

       bool IsGameReady() => gameWorld != null && gameWorld.AllAlivePlayersList != null && gameWorld.AllAlivePlayersList.Count > 0 && player != null;
       GameWorld gameWorld { get => Singleton<GameWorld>.Instance; }
       GameTimerClass SessionTimer { get => Singleton<AbstractGame>.Instance.GameTimer; }
       Player player { get => gameWorld.MainPlayer; }
    }
}