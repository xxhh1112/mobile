using System.ComponentModel;
using Bit.iOS.Core.Renderers;
using Bit.iOS.Core.Utilities;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace Bit.iOS.Core.Renderers
{
    //TODO [MAUI-Migration] [Critical] https://github.com/dotnet/maui/wiki/Using-Custom-Renderers-in-.NET-MAUI
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement is Button)
            {
                UpdateFont();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Button.FontAttributesProperty.PropertyName)
            {
                UpdateFont();
            }
        }

        private void UpdateFont()
        {
            var pointSize = iOSHelpers.GetAccessibleFont<Button>(Element.FontSize);
            if (pointSize != null)
            {
                //TODO MAUI
                //Control.Font = UIFont.FromDescriptor(Element.Font.ToUIFont().FontDescriptor, pointSize.Value);
            }
        }
    }
}
