using Avalonia;
using Avalonia.Interactivity;
using kursadarbs_reactiveUI.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace kursadarbs_reactiveUI.ViewModels
{
    public partial class ToDoViewModel : ViewModelBase
    {
        public ObservableCollection<ToDoViewModel> ToDoItems { get; } = new ObservableCollection<ToDoViewModel>();
        public ToDoViewModel()
        {

        }

        public ToDoViewModel(ToDoItem item)
        {
            IsChecked = item.IsChecked;
            Content = item.Content;
        }

        private bool _isChecked;

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
        public ToDoItem GetToDoItem()
        {
            return new ToDoItem()
            {
                IsChecked = this.IsChecked,
                Content = this.Content
            };
        }
        
        private string? _newItemContent;
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