using System;
using ColossalFramework;
using ICities;
using JetBrains.Annotations;
using UnityEngine;

namespace FrameRateLimiter
{
    public class FpsLimiterMod : IUserMod
    {
        public const String settingsFileName = "FrameRateLimiter";
        public const string version = "1.0.0";
        public string Name
        {
            get { return "Frame rate Limiter " + version; }
        }
        public string Description
        {
            get { return "This mod adds adds to ability to select a maximum frame rate in the existing display settings."; }
        }

        public FpsLimiterMod() {
            try
            {
                // Creating setting file
                GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = settingsFileName } });
            }
            catch (Exception e)
            {
                Debug.Log("Couldn't load/create the setting file.");
                Debug.LogException(e);
            }
        }


        [UsedImplicitly]
        public void OnEnabled() => FrameRateLimiter.StartMod();

        [UsedImplicitly]
        public void OnDisabled() => FrameRateLimiter.EndMod();
    }

}
