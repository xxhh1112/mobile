#if IOS
using System.ComponentModel;
using Bit.App.Controls;
using Foundation;
using WebKit;

using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;

namespace Bit.App.Platform.iOS.Renderers
{
    //TODO [MAUI-Migration] [Critical] https://github.com/dotnet/maui/wiki/Using-Custom-Renderers-in-.NET-MAUI https://github.com/jsuarezruiz/mvpsummit2022-dotnet-maui#renderers
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler
    {
        private const string JSFunction =
            "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";

        private WKUserContentController _userController;

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                _userController = new WKUserContentController();
                var script = new WKUserScript(new NSString(JSFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
                _userController.AddUserScript(script);
                _userController.AddScriptMessageHandler(this, "invokeAction");

                var config = new WKWebViewConfiguration { UserContentController = _userController };
                var webView = new WKWebView(Frame, config);
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                _userController.RemoveAllUserScripts();
                _userController.RemoveScriptMessageHandler("invokeAction");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                if (Element.Uri != null)
                {
                    Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Uri)));
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == HybridWebView.UriProperty.PropertyName && Element.Uri != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Uri)));
            }
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            Element.InvokeAction(message.Body.ToString());
        }
    }
}
#endif