using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Internals;
using Microsoft.Maui.Platform.iOS;

namespace Bit.iOS.Core.Utilities
{
    public static class FontElementExtensions
    {
        public static UIFont ToUIFont(this IFontElement fontElement)
        {
            var fontSize = fontElement.FontSize;
            var fontAttributes = fontElement.FontAttributes;
            var fontFamily = fontElement.FontFamily;

            return fontFamily is null
                ? Font.SystemFontOfSize(fontSize, fontAttributes).ToUIFont()
                : Font.OfSize(fontFamily, fontSize).WithAttributes(fontAttributes).ToUIFont();
        }
    }
}
