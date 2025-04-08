using System;
using ColossalFramework;
using ICities;
using JetBrains.Annotations;
using UnityEngine;

namespace FrameRateLimiter
{
    public class FrameRateLimiterMod : IUserMod
    {
        public const String settingsFileName = "FrameRateLimiter";
        public const string version = "1.0.0";
        public string Name => $"Frame rate Limiter {version}";
        public string Description => "This mod adds the ability to select a maximum frame rate in the existing display settings.";

        public FrameRateLimiterMod()
        {
            try
            {
                // Creating setting file
                GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = settingsFileName } });
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load or create the settings file '{settingsFileName}'. Exception: {e.Message}");
                Debug.LogException(e);
                Debug.Log(typeof(Patcher).GetMethod("UpdateVSyncPostfix"));
            }
        }

        [UsedImplicitly]
        public void OnEnabled() => FrameRateLimiter.StartMod();

        [UsedImplicitly]
        public void OnDisabled() => FrameRateLimiter.EndMod();
    }

}
