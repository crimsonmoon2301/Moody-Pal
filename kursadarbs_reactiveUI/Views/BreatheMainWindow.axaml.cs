using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;
using kursadarbs_reactiveUI.Views;
using ReactiveUI;
namespace kursadarbs_reactiveUI.Views
{
    public partial class BreatheMainWindow : Window
    {
        public BreatheMainWindow()
        {
            InitializeComponent();
            DataContext = new BreatheMainWindowViewModel();
        }

        private void start_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            start_btn.IsEnabled = false;
            stop_btn.IsEnabled = true;
        }

        private void stop_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            start_btn.IsEnabled = true;
            stop_btn.IsEnabled = false;
        }
    }
}