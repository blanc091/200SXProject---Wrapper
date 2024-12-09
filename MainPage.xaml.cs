using Microsoft.Maui.Controls;
#if ANDROID
using Android.Webkit;
#endif
namespace _200SXProject___MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            WebView.Source = "https://www.200sxproject.com";
            ConfigureWebView();
        }
        private void ConfigureWebView()
        {
            #if ANDROID
            WebView.Navigated += (sender, args) =>
            {
                var androidWebView = (Android.Webkit.WebView)WebView.Handler.PlatformView;
                androidWebView.Settings.JavaScriptEnabled = true;
                androidWebView.Settings.DomStorageEnabled = true;
                Android.Webkit.CookieManager.Instance.SetAcceptCookie(true);
            };
            #endif
            #if IOS
                                WebView.Navigated += (sender, args) =>
                                {
                                    // iOS-specific settings (if needed)
                                };
            #endif
        }
    }
}