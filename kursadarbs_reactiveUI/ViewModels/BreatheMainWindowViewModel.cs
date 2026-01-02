using Avalonia;
using Avalonia.Interactivity;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace kursadarbs_reactiveUI.ViewModels
{
    public class BreatheMainWindowViewModel : ViewModelBase
    {
        public BreatheMainWindowViewModel()
        {
            _CurrentPage = Pages[0];

            NavigateNextCommand = ReactiveCommand.Create(NavigateNext);
            NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious);
        }
        private readonly ViewModelBase[] Pages =
        {
            new BreatheMainViewModel(),
            new BreatheViewModel()
        };
        private ViewModelBase _CurrentPage;
        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        public ICommand NavigateNextCommand { get; }
        public ICommand NavigatePreviousCommand { get; }
        private void NavigateNext()
        {
            var index = Pages.IndexOf(CurrentPage) + 1;
            CurrentPage = Pages[index]; 
        }
        private void NavigatePrevious()
        {
            var index = Pages.IndexOf(CurrentPage) - 1;
            CurrentPage = Pages[index];
        }
        //public void ShowNotes()
        //{
        //    CurrentPage = Pages[0];
        //}
        //public void ShowPomo()
        //{
        //    CurrentPage = Pages[1];
        //}
        //public void ShowTodo()
        //{
        //    CurrentPage = Pages[2];
        //}
    }
}
