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
            start_btn.IsVisible = false;
            stop_btn.IsVisible = true;
            differentexam_btn.IsVisible = false;
        }

        private void stop_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            start_btn.IsVisible = true;
            stop_btn.IsVisible = false;
            differentexam_btn.IsVisible = true;
        }

        private void differentexam_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            start_btn.IsVisible = false;
            stop_btn.IsVisible = false;
            differentexam_btn.IsVisible = false;

            // show the selection buttons
            box_btn.IsVisible = true;
            calmbreath_btn.IsVisible = true;
            deep_btn.IsVisible = true;
        }

        private void box_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // selection buttons
            box_btn.IsVisible = false;
            calmbreath_btn.IsVisible = false;
            deep_btn.IsVisible = false;
            //
            start_btn.IsVisible = true;
            stop_btn.IsVisible = false;
            differentexam_btn.IsVisible = true;
        }

        private void calmbreath_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            box_btn.IsVisible = false;
            calmbreath_btn.IsVisible = false;
            deep_btn.IsVisible = false;
            //
            start_btn.IsVisible = true;
            stop_btn.IsVisible = false;
            differentexam_btn.IsVisible = true;
        }

        private void deep_btn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            box_btn.IsVisible = false;
            calmbreath_btn.IsVisible = false;
            deep_btn.IsVisible = false;
            //
            start_btn.IsVisible = true;
            stop_btn.IsVisible = false;
            differentexam_btn.IsVisible = true;
        }
    }
}