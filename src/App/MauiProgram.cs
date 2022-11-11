using System;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ZXing.Net.Maui;

namespace Bit.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp(Action<IEffectsBuilder> effectsBuilder, Action<IMauiHandlersCollection> handlersCollection)
        {
            return MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCompatibility()
                .UseBarcodeReader()
                .ConfigureEffects(effectsBuilder)
                .ConfigureMauiHandlers(handlersCollection)
                .Build();
        }
    }
}
