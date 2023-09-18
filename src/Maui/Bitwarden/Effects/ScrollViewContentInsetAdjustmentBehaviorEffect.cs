using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Bit.App.Effects
{
    public enum ScrollContentInsetAdjustmentBehavior
    {
        Automatic,
        ScrollableAxes,
        Never,
        Always
    }

    public class ScrollViewContentInsetAdjustmentBehaviorEffect : RoutingEffect
    {
        public static readonly BindableProperty ContentInsetAdjustmentBehaviorProperty =
          BindableProperty.CreateAttached("ContentInsetAdjustmentBehavior", typeof(ScrollContentInsetAdjustmentBehavior), typeof(ScrollViewContentInsetAdjustmentBehaviorEffect), ScrollContentInsetAdjustmentBehavior.Automatic);

        public static ScrollContentInsetAdjustmentBehavior GetContentInsetAdjustmentBehavior(BindableObject view)
        {
            return (ScrollContentInsetAdjustmentBehavior)view.GetValue(ContentInsetAdjustmentBehaviorProperty);
        }

        public static void SetContentInsetAdjustmentBehavior(BindableObject view, ScrollContentInsetAdjustmentBehavior value)
        {
            view.SetValue(ContentInsetAdjustmentBehaviorProperty, value);
        }

        public ScrollViewContentInsetAdjustmentBehaviorEffect()
            : base($"Bitwarden.{nameof(ScrollViewContentInsetAdjustmentBehaviorEffect)}")
        {
        }
    }

#if IOS
    public class ScrollViewContentInsetAdjustmentBehaviorPlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element != null && Control is UIScrollView scrollView)
            {
                switch (App.Effects.ScrollViewContentInsetAdjustmentBehaviorEffect.GetContentInsetAdjustmentBehavior(Element))
                {
                    case App.Effects.ScrollContentInsetAdjustmentBehavior.Automatic:
                        scrollView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Automatic;
                        break;
                    case App.Effects.ScrollContentInsetAdjustmentBehavior.ScrollableAxes:
                        scrollView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.ScrollableAxes;
                        break;
                    case App.Effects.ScrollContentInsetAdjustmentBehavior.Never:
                        scrollView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
                        break;
                    case App.Effects.ScrollContentInsetAdjustmentBehavior.Always:
                        scrollView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Always;
                        break;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
#endif
}
