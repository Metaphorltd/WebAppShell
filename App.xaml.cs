using MauiTubePlayer.Views;

namespace WebAppShell;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new StartPage());
	}
	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = base.CreateWindow(activationState);
		if (DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			// window size of mobiel app
			const int newWidth = 400;
			const int newHeight = 800;
        
			window.Width = newWidth;
			window.Height = newHeight;
		}
		

		return window;
	}
}
