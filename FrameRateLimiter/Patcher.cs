using ColossalFramework;
using HarmonyLib;

namespace FrameRateLimiter
{
    public static class Patcher
    {
        private const string HarmonyId = "Madr0ne.FrameRateLimiter";
        private static bool patched = false;

        public static void PatchAll()
        {
            if (patched) return;

            patched = true;

            new Harmony(HarmonyId).PatchAll(typeof(Patcher).Assembly);
        }

        public static void UnpatchAll()
        {
            if (!patched) return;
            new Harmony(HarmonyId).UnpatchAll(HarmonyId);

            patched = false;
        }

        [HarmonyPatch(typeof(OptionsGraphicsPanel), "UpdateVSync")]
        public static class Patch
        {
            public static void Postfix(SavedInt ___m_VSync)
            {
                if (___m_VSync.value > 0)
                {
                    FrameRateLimiter.Instance.Panel.Disable();
                }
                else
                {
                    FrameRateLimiter.Instance.Panel.Enable();
                }
            }
        }
    }
}
