using System;
using ColossalFramework;
using ColossalFramework.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace FrameRateLimiter
{
    public class UISettingsLimitPanel : UIPanel
    {
        private readonly SavedInt frameRateLimit = new SavedInt("FPSLimit", FrameRateLimiterMod.settingsFileName, 60, autoUpdate: true);
        private const int MaxFrameRate = 500;

        [UsedImplicitly]
        public override void Start()
        {
            base.Start();
            // Set up the panel
            area = new Vector4(300, 107, 232, 72);
            autoLayoutDirection = LayoutDirection.Vertical;
            autoLayoutPadding = new RectOffset(1, 0, 2, 0);
            name = "FPSL_FrameRate";
            autoLayout = true;
            height = 20;

            // Add a label
            UILabel label = AddUIComponent<UILabel>();
            label.name = "FPSL_Label";
            label.textScale = 1.125f;

            // Make and set up slider
            UISlider slider = AddUIComponent<UISlider>();
            slider.eventValueChanged += (component, value) =>
            {
                int intValue = (int)value;
                frameRateLimit.value = intValue;
                Application.targetFrameRate = intValue < MaxFrameRate ? intValue : -1;
                label.text = String.Format("Maximum Frame Rate: {0}", intValue < MaxFrameRate ? intValue.ToString() : "Unlimited");
            };

            slider.name = "FPSL_FrameRateLimit";
            slider.minValue = 5;
            slider.maxValue = MaxFrameRate;
            slider.value = frameRateLimit.value;
            slider.stepSize = 5;
            slider.width = 226;
            slider.height = 17;
            slider.backgroundSprite = "OptionsScrollbarTrack";

            // Don't forget the pesky sprite to go with it
            UISprite thumb = slider.AddUIComponent<UISprite>();
            slider.thumbObject = thumb;
            thumb.name = "FPSL_Thumb";
            thumb.spriteName = "OptionsScrollbarThumb";
            thumb.area = new Vector4(101, 0, 16, 16);
            thumb.disabledColor = new Color32(71, 71, 71, 255);
        }

        [UsedImplicitly]
        public override void OnDestroy()
        {
            base.OnDestroy();
            Application.targetFrameRate = -1;
        }
    }
}
