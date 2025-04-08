using System;
using ColossalFramework;
using ColossalFramework.UI;
using JetBrains.Annotations;
using UnityEngine;
using static RenderManager;

namespace FrameRateLimiter
{
    public class UISettingsLimitPanel : UIPanel
    {
        private readonly SavedInt frameRateLimit = new SavedInt("FPSLimit", FpsLimiterMod.settingsFileName, 60, autoUpdate: true);

        [UsedImplicitly]
        public override void Start()
        {
            base.Start();
            area = new Vector4(300, 107, 232, 72);
            autoLayoutDirection = LayoutDirection.Vertical;
            autoLayoutPadding = new RectOffset(1, 0, 2, 0);
            name = "FPSL_FrameRate";
            autoLayout = true;
            height = 20;


            UILabel label = AddUIComponent<UILabel>();
            label.name = "FPSL_Label";
            label.textScale = 1.125f;

            UISlider slider = AddUIComponent<UISlider>();
            slider.eventValueChanged += (component, value) => {
                int intValue = (int)value;
                frameRateLimit.value = intValue;
                Application.targetFrameRate = intValue < 500 ? intValue : -1;
                label.text = String.Format("Maximum Frame Rate: {0}", intValue < 500 ? intValue.ToString() : "Unlimited");
            };

            slider.name = "FPSL_FrameRateLimit";
            slider.minValue = 0;
            slider.maxValue = 500;
            slider.value = frameRateLimit.value;
            slider.stepSize = 5;
            slider.width = 226;
            slider.height = 17;
            slider.backgroundSprite = "OptionsScrollbarTrack";


            UISprite thumb = slider.AddUIComponent<UISprite>();
            slider.thumbObject = thumb;
            thumb.name = "FPSL_Thumb";
            thumb.spriteName = "OptionsScrollbarThumb";
            thumb.area = new Vector4(101, 0, 16, 16);
        }
    }

}
