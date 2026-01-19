using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.Services;
using kursadarbs_reactiveUI.ViewModels;
using System.Linq;

namespace kursadarbs_reactiveUI.Views
{
    public partial class NotesView : UserControl
    {
        public NotesView()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }

        private async void Journal_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is NotesViewModel vm)
            {
                vm.SaveItems();
            }
        }

        private void Journal_Unloaded_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }
    }
}
