using System;
using System.Collections;
using ColossalFramework;
using ColossalFramework.UI;
using FpsLimiter;
using JetBrains.Annotations;
using UnityEngine;

namespace FrameRateLimiter
{
    internal class FrameRateLimiter : MonoBehaviour
    {
        public static FrameRateLimiter Instance;
        public UISettingsLimitPanel Panel;

        internal static void StartMod()
        {
            var go = new GameObject(nameof(FrameRateLimiter), typeof(FrameRateLimiter));
            DontDestroyOnLoad(go);
        }

        internal static void EndMod()
        {
            Destroy(Instance);
        }

        [UsedImplicitly]
        void Awake()
        {
            Instance = this;
        }
        [UsedImplicitly]
        IEnumerator Start()
        {
            yield return new WaitUntil(() => GameObject.Find("DisplaySettings") != null);
            UIPanel DisplaySettings = GameObject.Find("DisplaySettings").GetComponent<UIPanel>();
            Panel = DisplaySettings.AddUIComponent<UISettingsLimitPanel>();
        }

        [UsedImplicitly]
        void OnDestroy()
        {
            Application.targetFrameRate = -1;
            Destroy(Panel.gameObject);
            Instance = null;
            Panel = null;
            //Patcher.UnpatchAll();
        }
    }
}
