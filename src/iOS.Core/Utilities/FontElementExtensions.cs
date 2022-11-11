using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Platform;

namespace Bit.iOS.Core.Utilities
{
    public static class FontElementExtensions
    {

        // TODO: [MAUI-Migration] [Critical] Compiling but big untested change

        public static UIFont ToUIFont(this Font font)
        {
            var fontSize = font.Size;
            var fontAttributes = font.GetFontAttributes();
            var fontFamily = font.Family;
            var fontWeight = fontAttributes == FontAttributes.Bold ? UIFontWeight.Bold : UIFontWeight.Regular;

            return fontFamily is null
                ? UIFont.SystemFontOfSize((nfloat)fontSize, fontWeight)
                : UIFont.FromName(fontFamily, (nfloat)fontSize);
        }
    }
}
