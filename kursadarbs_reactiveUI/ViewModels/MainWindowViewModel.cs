using Avalonia.Interactivity;
using ReactiveUI;

namespace kursadarbs_reactiveUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";
        public string Infotip
        {
            get => _infoTip;
            set { this.RaiseAndSetIfChanged(ref _infoTip, value); }
        }
        private string _infoTip = "Hover over a button to get more info about how the program adapts!";

        public void Info_hover (object sender, RoutedEventArgs args)
        {

        }
    }
}
