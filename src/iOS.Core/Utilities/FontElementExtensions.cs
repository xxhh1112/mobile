using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using UIKit;

namespace Bit.iOS.Core.Utilities
{
    public static class FontElementExtensions
    {
        public static UIFont ToUIFont(this IFontElement fontElement)
        {
            var fontSize = fontElement.FontSize;
            var fontAttributes = fontElement.FontAttributes;
            var fontFamily = fontElement.FontFamily;
            var fontWeight = fontAttributes == FontAttributes.Bold ? UIFontWeight.Bold : UIFontWeight.Regular;

            return fontFamily is null
                ? UIFont.SystemFontOfSize((nfloat)fontSize, fontWeight)
                : UIFont.FromName(fontFamily, (nfloat)fontSize);

            //return fontFamily is null
            //    ? Font.SystemFontOfSize(fontSize, fontAttributes).ToUIFont()
            //    : Font.OfSize(fontFamily, fontSize).WithAttributes(fontAttributes).ToUIFont();
        }
    }
}
