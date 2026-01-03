using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;

namespace kursadarbs_reactiveUI.Views
{
    public partial class DeepBreathingView : UserControl
    {
        public DeepBreathingView()
        {
            InitializeComponent();
        }

        private void DeepBreath_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is DeepBreathingViewModel vm)
            {
                vm.StartTimer();
            }
        }
        private void DeepBreath_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is DeepBreathingViewModel vm)
            {
                vm.StartTimer();
            }
        }
    }
}