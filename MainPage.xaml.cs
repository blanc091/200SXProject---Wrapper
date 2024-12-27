using Microsoft.Maui.Controls;
using MauiWebView = Microsoft.Maui.Controls.WebView;
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
			Shell.SetNavBarIsVisible(this, false);
			WebView.Source = "https://www.200sxproject.com";
			ConfigureWebView();
		}
		private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
		{
			if (e.Result == WebNavigationResult.Failure)
			{
				await DisplayAlert("Error", "Failed to load page.", "OK");
				Application.Current.MainPage = new ErrorPage();
			}
		}
		private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
		{
			
		}
		protected override bool OnBackButtonPressed()
		{
			var webView = this.FindByName<MauiWebView>("WebView");

			if (webView != null && webView.CanGoBack)
			{
				webView.GoBack();
				return true;
			}

			return base.OnBackButtonPressed();
		}
		private void ConfigureWebView()
		{
			WebView.Navigated += WebView_Navigated;
			WebView.Navigating += WebView_Navigating;
#if ANDROID
            WebView.HandlerChanged += (sender, args) =>
            {
                if (WebView.Handler?.PlatformView is Android.Webkit.WebView androidWebView)
                {
                    androidWebView.Settings.JavaScriptEnabled = true;
                    androidWebView.Settings.DomStorageEnabled = true;
                    androidWebView.Settings.AllowFileAccess = true;
                    androidWebView.Settings.AllowContentAccess = true;
                    Android.Webkit.CookieManager.Instance.SetAcceptCookie(true);
                }
            };
#endif
		}
	}
}
