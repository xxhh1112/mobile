using Bit.App.Handlers;

namespace Bit.App
{
    public class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            return Core.MauiProgram.ConfigureMauiAppBuilder(
                effects =>
                {
#if ANDROID
                    effects.Add<Effects.FabShadowEffect, Effects.FabShadowPlatformEffect>();
#else
                    effects.Add<Effects.NoEmojiKeyboardEffect, Bit.iOS.Core.Effects.NoEmojiKeyboardEffect>();
                    effects.Add<Effects.ScrollEnabledEffect, Effects.ScrollEnabledPlatformEffect>();
                    effects.Add<Effects.ScrollViewContentInsetAdjustmentBehaviorEffect, Bit.App.Effects.ScrollViewContentInsetAdjustmentBehaviorPlatformEffect>();
#endif
                },
                handlers =>
                {
#if ANDROID
                    new EntryHandlerMappings().Setup();
                    new EditorHandlerMappings().Setup();
                    new LabelHandlerMappings().Setup();
                    new PickerHandlerMappings().Setup();
                    new SearchBarHandlerMappings().Setup();
                    new SwitchHandlerMappings().Setup();
                    new DatePickerHandlerMappings().Setup();
                    new SliderHandlerMappings().Setup();
                    new StepperHandlerMappings().Setup();
                    new TimePickerHandlerMappings().Setup();
                    new ButtonHandlerMappings().Setup();
#else
                    iOS.Core.Handlers.ButtonHandlerMappings.Setup();
                    iOS.Core.Handlers.DatePickerHandlerMappings.Setup();
                    iOS.Core.Handlers.EditorHandlerMappings.Setup();
                    iOS.Core.Handlers.EntryHandlerMappings.Setup();
                    //iOS.Core.Handlers.LabelHandlerMappings.Setup();
                    iOS.Core.Handlers.PickerHandlerMappings.Setup();
                    iOS.Core.Handlers.SearchBarHandlerMappings.Setup();
                    iOS.Core.Handlers.StepperHandlerMappings.Setup();
                    iOS.Core.Handlers.TimePickerHandlerMappings.Setup();
#endif
                }
            ).Build();
        }
    }
}
