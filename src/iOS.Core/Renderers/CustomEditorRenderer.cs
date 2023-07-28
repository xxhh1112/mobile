using Bit.iOS.Core.Renderers;
using System.ComponentModel;
using UIKit;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace Bit.iOS.Core.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is Editor)
            {
                var descriptor = UIFontDescriptor.PreferredBody;
                Control.Font = UIFont.FromDescriptor(descriptor, descriptor.PointSize);
                // Remove padding
                Control.TextContainerInset = new UIEdgeInsets(0, 0, 0, 0);
                Control.TextContainer.LineFragmentPadding = 0;
                UpdateTintColor();
                UpdateKeyboardAppearance();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Editor.TextColorProperty.PropertyName)
            {
                UpdateTintColor();
            }
        }

        private void UpdateTintColor()
        {
            Control.TintColor = Element.TextColor.ToUIColor();
        }

        private void UpdateKeyboardAppearance()
        {
            if (!Utilities.ThemeHelpers.LightTheme)
            {
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            }
        }
    }
}
