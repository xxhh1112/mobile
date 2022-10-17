using Android.Content;
using Android.Views.InputMethods;
using Bit.Droid.Renderers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace Bit.Droid.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context)
            : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement != null)
            {
                try
                {
                    var magId = Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                    var magImage = (Android.Widget.ImageView)Control.FindViewById(magId);
                    magImage.LayoutParameters = new Android.Widget.LinearLayout.LayoutParams(0, 0);
                }
                catch { }
                // TODO: [MAUI-Migration] check if this setting of options work
                Control.ImeOptions = (int)((ImeAction)Control.ImeOptions | (ImeAction)ImeFlags.NoPersonalizedLearning |
                    (ImeAction)ImeFlags.NoExtractUi);
            }
        }
    }
}
