using Microsoft.Maui.Controls;
using MauiWebView = Microsoft.Maui.Controls.WebView;

namespace _200SXProject___MAUI
{
	public partial class ErrorPage : ContentPage
	{
		public ErrorPage()
		{
			InitializeComponent();
		}
	
		private void RetryButton_Clicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new MainPage();
		}
	}
}