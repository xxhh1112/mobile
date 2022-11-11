using Bit.iOS.Core.Effects;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;

//TODO: [MAUI-Migration] TEST https://github.com/jsuarezruiz/xamarin-forms-to-net-maui/tree/main/Effects
[assembly: ResolutionGroupName("Bitwarden")]
[assembly: ExportEffect(typeof(ScrollEnabledEffect), "ScrollEnabledEffect")]
namespace Bit.iOS.Core.Effects
{
    public class ScrollEnabledEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // this can be for any view that inherits from UIScrollView like UITextView.
            if (Element != null && Control is UIScrollView scrollView)
            {
                scrollView.ScrollEnabled = App.Effects.ScrollEnabledEffect.GetIsScrollEnabled(Element);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
