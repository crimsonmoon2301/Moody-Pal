using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Interactivity;
using ReactiveUI;
using DynamicData;
using System.Windows.Input;

namespace kursadarbs_reactiveUI.ViewModels
{
    internal class HappyAppViewModel : ViewModelBase
    {
        public HappyAppViewModel()
        {
            _CurrentPage = Pages[0];
        }
        private readonly ViewModelBase[] Pages =
        {
            new NotesViewModel(),
            new PomodoroViewModel(),
            new ToDoViewModel()
        };
        private ViewModelBase _CurrentPage;
        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        public void ShowNotes()
        {
            CurrentPage = Pages[0];
        }
        public void ShowPomo()
        {
            CurrentPage = Pages[1];
        }
        public void ShowTodo()
        {
            CurrentPage = Pages[2];
        }
    }
}
