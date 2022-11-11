using System.ComponentModel;
using Bit.App.Controls;
using Bit.iOS.Core.Renderers;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace Bit.iOS.Core.Renderers
{
    //TODO [MAUI-Migration] [Critical] https://github.com/dotnet/maui/wiki/Using-Custom-Renderers-in-.NET-MAUI
    public class ExtendedDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element is ExtendedDatePicker element)
            {
                // center text
                Control.TextAlignment = UITextAlignment.Center;

                // use placeholder until NullableDate set 
                if (!element.NullableDate.HasValue)
                {
                    Control.Text = element.PlaceHolder;
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == DatePicker.DateProperty.PropertyName ||
                e.PropertyName == DatePicker.FormatProperty.PropertyName)
            {
                if (Control != null && Element is ExtendedDatePicker element)
                {
                    if (Element.Format == element.PlaceHolder)
                    {
                        Control.Text = element.PlaceHolder;
                        return;
                    }
                }
            }
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
