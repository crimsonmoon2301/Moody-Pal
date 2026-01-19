using Avalonia;
using Avalonia.Interactivity;
using kursadarbs_reactiveUI.Models;
using kursadarbs_reactiveUI.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI.ViewModels
{
    public partial class ToDoViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> AddItemCommand { get; }
        public ReactiveCommand<ToDoViewModel, Unit> RemoveItemCommand { get; }
        public ObservableCollection<ToDoViewModel> ToDoItems { get; } = new();
        public ToDoViewModel()
        {
            AddItemCommand = ReactiveCommand.Create(AddItem);
            RemoveItemCommand = ReactiveCommand.Create<ToDoViewModel>(RemoveItem);

            LoadItems();
        }

       
        public ToDoViewModel(ToDoItem item)
        {
            IsChecked = item.IsChecked;
            Content = item.Content;
            IsEnabled = item.IsEnabled;

        }

        private bool _isChecked;
        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                this.RaiseAndSetIfChanged(ref _isEnabled, value);
            }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                this.RaiseAndSetIfChanged(ref _isChecked, value);
            }
        }
        private string? _content;
        public string Content
        {
            get { return _content; }
            set { this.RaiseAndSetIfChanged(ref _content, value); }
        }
        private string? _newItemContent;
        public string? NewItemContent
        {
            get { return _newItemContent; }
            set { this.RaiseAndSetIfChanged(ref _newItemContent, value); }
        }
        public ToDoItem GetToDoItem()
        {
            return new ToDoItem()
            {
                IsChecked = this.IsChecked,
                Content = this.Content,
                IsEnabled = this.IsEnabled
            };
        }
        
        private void AddItem()
        {
            // Add a new item to the list
            ToDoItems.Add(new ToDoViewModel() { Content = _newItemContent });

            // reset the NewItemContent
            _newItemContent = null;
        }
        private bool CanAddItem() => !string.IsNullOrWhiteSpace(_newItemContent);


        private void RemoveItem(ToDoViewModel item)
        {
            // Remove the given item from the list
            ToDoItems.Remove(item);
        }
        private async void LoadItems()
        {
            await Task.Delay(1000);
            var itemsLoaded = await ToDoListFileService.LoadFromFileAsync();
            if (itemsLoaded == null)
            {
                return;
            }
            foreach (var item in itemsLoaded)
            {
                ToDoItems.Add(new ToDoViewModel(item));
            }
        }
    }
}
