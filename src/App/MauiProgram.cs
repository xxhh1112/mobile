using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ZXing.Net.Maui;

namespace Bit.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            return MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .Build();
        }
    }
}
