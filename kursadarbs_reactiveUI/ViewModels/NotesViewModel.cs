using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using kursadarbs_reactiveUI.Models;

namespace kursadarbs_reactiveUI.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> AddEntryCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveEntryCommand { get; }
        public ObservableCollection<JournalItem> JournalItems { get; } = new();

        //public string Title
        //{
        //    get { return _titleText; }
        //    set { this.RaiseAndSetIfChanged(ref _titleText, value); }
        //}
        //private string _titleText;

        private string? _newEntry;
        public string? NewEntry
        {
            get { return _newEntry; }
            set { this.RaiseAndSetIfChanged(ref _newEntry, value); }
        }

        public string Content
        {
            get { return _content; }
            set { this.RaiseAndSetIfChanged(ref _content, value); }
        }
        private string? _content;

        public JournalItem? Selected
        {
            get => _selected;
            set { this.RaiseAndSetIfChanged(ref _selected, value); }

        }
        private JournalItem? _selected;
        public NotesViewModel()
        {
            AddEntryCommand = ReactiveCommand.Create(AddEntry);
            RemoveEntryCommand = ReactiveCommand.Create(RemoveEntry);
        }
        
        private DateTime _created;
        public void AddEntry()
        {
            var entry = new JournalItem
            {
                Title="New Journal Entry",
                Content = "",
                Created = DateTime.Now
            };
            JournalItems.Add(entry);
        }
        public void RemoveEntry()
        {
            if (Selected != null)
            {
                JournalItems.Remove(Selected);
            }
        }
    }
}
