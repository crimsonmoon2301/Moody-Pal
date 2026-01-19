using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using kursadarbs_reactiveUI.Models;
using kursadarbs_reactiveUI.Services;
using kursadarbs_reactiveUI.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI.Views
{
    public partial class ToDoView : UserControl
    {
        public ToDoView()
        {
            InitializeComponent();
        }

        private async void Todo_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (DataContext is ToDoViewModel vm)
            {
                var itemsToSave = vm.ToDoItems.Select(x => x.GetToDoItem());
                await ToDoListFileService.SaveToFileAsync(itemsToSave);

            }
        }

        private async void Todo_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
        }

        //private void Todo_Unloaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        //{
        //}
    }
}