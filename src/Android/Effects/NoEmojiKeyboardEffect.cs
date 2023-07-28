using Android.Widget;
using Bit.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

[assembly: ExportEffect(typeof(NoEmojiKeyboardEffect), nameof(NoEmojiKeyboardEffect))]
namespace Bit.Droid.Effects
{
    public class NoEmojiKeyboardEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is EditText editText)
            {
                editText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationVisiblePassword | Android.Text.InputTypes.TextFlagMultiLine;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

