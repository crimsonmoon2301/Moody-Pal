using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using kursadarbs_reactiveUI;
using kursadarbs_reactiveUI.Services;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using LibVLCSharp.Shared;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private readonly ToDoViewModel _todoViewModel = new ToDoViewModel();

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //Assets.Resources.Culture = new CultureInfo("lv-LV");
                var splashScreenVM = new SplashViewModel();
                var splashScreen = new Splash
                {
                    DataContext = splashScreenVM
                };
                desktop.MainWindow = splashScreen;

                splashScreen.Show();

                splashScreenVM.StartupMessage = Assets.Resources.StartupMessage;
                await Task.Delay(8000);

                var mainWin = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                desktop.MainWindow = mainWin;
                mainWin.Show();

                splashScreen.Close();
            }
            Core.Initialize();
            base.OnFrameworkInitializationCompleted();
        }
        
    }
}