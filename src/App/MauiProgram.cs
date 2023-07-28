using System;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ZXing.Net.Maui;

namespace Bit.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp(Action<IEffectsBuilder> effectsBuilder)
        {
            return MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCompatibility()
                .UseBarcodeReader()
                .UseSkiaSharp()
                .UseFFImageLoading()
                .ConfigureEffects(effectsBuilder)
                .ConfigureMauiHandlers((handlers) =>
                {
#if ANDROID
                    handlers.AddCompatibilityRenderer<Controls.HybridWebView, Platform.Android.Renderers.HybridWebViewRenderer>();
#elif IOS
                    handlers.AddCompatibilityRenderer<Controls.HybridWebView, Platform.iOS.Renderers.HybridWebViewRenderer>();
#endif
                })
                .Build();
        }
    }
}