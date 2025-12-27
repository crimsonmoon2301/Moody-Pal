using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var splashScreenVM = new SplashViewModel();
                var splashScreen = new Splash
                {
                    DataContext = splashScreenVM
                };
                desktop.MainWindow = splashScreen;

                splashScreen.Show();
                splashScreenVM.StartupMessage = "Loading...";
                await Task.Delay(2000);
                splashScreenVM.StartupMessage = "Good things come to those who wait...";
                await Task.Delay(3000);
                splashScreenVM.StartupMessage = "One step closer to productivity...";
                await Task.Delay(4000);
                splashScreenVM.StartupMessage = "Ready!";
                await Task.Delay(500);

                var mainWin = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                desktop.MainWindow = mainWin;
                mainWin.Show();

                splashScreen.Close();
            }

            base.OnFrameworkInitializationCompleted();
        }

    }
}