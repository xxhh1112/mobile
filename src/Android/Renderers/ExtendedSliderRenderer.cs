using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidX.Core.Content.Resources;
using Bit.App.Controls;
using Bit.Droid.Renderers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;

[assembly: ExportRenderer(typeof(ExtendedSlider), typeof(ExtendedSliderRenderer))]
namespace Bit.Droid.Renderers
{
    public class ExtendedSliderRenderer : SliderRenderer
    {
        public ExtendedSliderRenderer(Context context)
            : base(context)
        {}

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            UpdateColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ExtendedSlider.ThumbBorderColorProperty.PropertyName)
            {
                UpdateColor();
            }
        }
        
        private void UpdateColor()
        {
            if (Control != null && Element is ExtendedSlider view)
            {
                var t = ResourcesCompat.GetDrawable(Resources, Resource.Drawable.slider_thumb, null);
                if (t is GradientDrawable thumb)
                {
                    // TODO: [MAUI-Migration] Color.Default, maybe the default on the control should be null to check it here against null
                    if (view.ThumbColor == Colors.Black)
                    {
                        thumb.SetColor(Colors.White.ToAndroid());
                    }
                    else
                    {
                        thumb.SetColor(view.ThumbColor.ToAndroid());
                    }
                    thumb.SetStroke(3, view.ThumbBorderColor.ToAndroid());
                    Control.SetThumb(thumb);
                }
            }
        }
    }
}
