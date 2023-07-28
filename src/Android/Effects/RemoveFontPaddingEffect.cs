using Android.Widget;
using Bit.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportEffect(typeof(RemoveFontPaddingEffect), nameof(RemoveFontPaddingEffect))]
namespace Bit.Droid.Effects
{
    public class RemoveFontPaddingEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is TextView textView)
            {
                textView.SetIncludeFontPadding(false);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}