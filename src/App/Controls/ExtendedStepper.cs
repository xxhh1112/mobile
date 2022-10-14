using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Bit.App.Controls
{
    public class ExtendedStepper : Stepper
    {
        // TODO: [MAUI-Migration] Color.Default
        public static readonly BindableProperty StepperBackgroundColorProperty = BindableProperty.Create(
            nameof(StepperBackgroundColor), typeof(Color), typeof(ExtendedStepper), Colors.White);

        // TODO: [MAUI-Migration] Color.Default
        public static readonly BindableProperty StepperForegroundColorProperty = BindableProperty.Create(
            nameof(StepperForegroundColor), typeof(Color), typeof(ExtendedStepper), Colors.Black);

        public Color StepperBackgroundColor
        {
            get => (Color)GetValue(StepperBackgroundColorProperty);
            set => SetValue(StepperBackgroundColorProperty, value);
        }

        public Color StepperForegroundColor
        {
            get => (Color)GetValue(StepperForegroundColorProperty);
            set => SetValue(StepperForegroundColorProperty, value);
        }
    }
}
