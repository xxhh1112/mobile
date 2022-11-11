using Bit.iOS.Core.Renderers;
using Bit.iOS.Core.Utilities;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace Bit.iOS.Core.Renderers
{
    //TODO [MAUI-Migration] [Critical] https://github.com/dotnet/maui/wiki/Using-Custom-Renderers-in-.NET-MAUI
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is Picker)
            {
                var descriptor = UIFontDescriptor.PreferredBody;
                Control.Font = UIFont.FromDescriptor(descriptor, descriptor.PointSize);
                iOSHelpers.SetBottomBorder(Control);
                UpdateKeyboardAppearance();
            }
        }

        private void UpdateKeyboardAppearance()
        {
            if (!ThemeHelpers.LightTheme)
            {
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            }
        }
    }
}
