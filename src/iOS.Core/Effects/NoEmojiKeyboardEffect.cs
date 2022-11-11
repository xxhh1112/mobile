using System;
using Bit.iOS.Core.Effects;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;

//TODO: [MAUI-Migration] TEST https://github.com/jsuarezruiz/xamarin-forms-to-net-maui/tree/main/Effects
[assembly: ExportEffect(typeof(NoEmojiKeyboardEffect), nameof(NoEmojiKeyboardEffect))]
namespace Bit.iOS.Core.Effects
{
    public class NoEmojiKeyboardEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element != null && Control is UITextField textField)
            {
                textField.KeyboardType = UIKeyboardType.ASCIICapable;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}

