using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Bit.App.Controls
{
    public class ExtendedSlider : Slider
    {
        // TODO: [MAUI-Migration] Color.Default
        public static readonly BindableProperty ThumbBorderColorProperty = BindableProperty.Create(
            nameof(ThumbBorderColor), typeof(Color), typeof(ExtendedSlider), Colors.Black);

        public Color ThumbBorderColor
        {
            get => (Color)GetValue(ThumbBorderColorProperty);
            set => SetValue(ThumbBorderColorProperty, value);
        }
    }
}
