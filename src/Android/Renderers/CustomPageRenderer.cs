using System;
using Android.App;
using Android.Content;
using AndroidX.AppCompat.Widget;
using Bit.App.Resources;
using Bit.Droid.Renderers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;

[assembly: ExportRenderer(typeof(ContentPage), typeof(CustomPageRenderer))]
namespace Bit.Droid.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        public CustomPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            Activity context = (Activity)this.Context;
            var toolbar = context.FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            if(toolbar != null)
            {
                toolbar.NavigationContentDescription = AppResources.TapToGoBack;
            }
        }
    }
}
