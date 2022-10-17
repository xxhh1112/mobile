using Android.Content;
using Bit.App.Controls;
using Bit.Droid.Renderers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(ExtendedGrid), typeof(ExtendedGridRenderer))]
namespace Bit.Droid.Renderers
{
    public class ExtendedGridRenderer : ViewRenderer
    {
        public ExtendedGridRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<View> elementChangedEvent)
        {
            base.OnElementChanged(elementChangedEvent);
            if (elementChangedEvent.NewElement != null)
            {
                SetBackgroundResource(Resource.Drawable.list_item_bg);
            }
        }
    }
}
