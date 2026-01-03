using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using kursadarbs_reactiveUI.ViewModels;
using System.Threading.Tasks;
using System.Timers;

namespace kursadarbs_reactiveUI.Views
{
    public partial class BreatheView : UserControl
    {
        public BreatheView()
        {
            InitializeComponent();
        }

        private void Breathing_view_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is BreatheViewModel vm)
            {
                vm.StartTimer();
            }
        }

        private void Breathing_view_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is BreatheViewModel vm1)
            {
                vm1.StopTimer();
            }
        }
    }
}