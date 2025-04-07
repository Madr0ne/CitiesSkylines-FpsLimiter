using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ColossalFramework.Globalization;
using ColossalFramework.Plugins;
using ICities;
using JetBrains.Annotations;
using UnityEngine;

namespace FpsLimiter
{
    public class FpsLimiterMod : IUserMod
    {

        public string Name => "FPS limiter";

        public string Description => "Limit your game's FPS";

        [UsedImplicitly]
        public void OnEnabled()
        {
            Debug.Log("aaaa");
            Application.targetFrameRate = 60;
        }

        [UsedImplicitly]
        public void OnDisabled()
        {
            Debug.Log("bbb");
            Application.targetFrameRate = -1;
        }
    }
}
