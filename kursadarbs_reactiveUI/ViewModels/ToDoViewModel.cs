using Avalonia;
using Avalonia.Interactivity;
using kursadarbs_reactiveUI.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

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
    }
}