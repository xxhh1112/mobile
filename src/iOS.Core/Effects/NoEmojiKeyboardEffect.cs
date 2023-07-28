using System;
using Bit.iOS.Core.Effects;
using UIKit;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;

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

