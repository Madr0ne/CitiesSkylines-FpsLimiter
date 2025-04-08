using System.Collections;
using CitiesHarmony.API;
using ColossalFramework.UI;
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
            HarmonyHelper.EnsureHarmonyInstalled();
            var go = new GameObject(nameof(FrameRateLimiter), typeof(FrameRateLimiter));
            DontDestroyOnLoad(go);
        }

        internal static void EndMod()
        {
            Destroy(Instance);
            if (HarmonyHelper.IsHarmonyInstalled) Patcher.UnpatchAll();
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
            if (HarmonyHelper.IsHarmonyInstalled) Patcher.PatchAll(); // Harmony patch relies on objecs created by our custom pane
        }

        [UsedImplicitly]
        void OnDestroy()
        {
            Destroy(Panel.gameObject);
            Instance = null;
        }
    }
}
