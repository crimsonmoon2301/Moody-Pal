using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.ViewModels;

namespace kursadarbs_reactiveUI.Views
{
    public partial class CalmBreathingView : UserControl
    {
        public CalmBreathingView()
        {
            InitializeComponent();
        }

        private void calmbreathing_view_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is CalmBreathingViewModel vm)
            {
                vm.StartTimer();
            }
        }

        private void calmbreathing_view_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is CalmBreathingViewModel vm)
            {
                vm.StopTimer();
            }
        }
    }
}