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
            NavigateToMenu = ReactiveCommand.Create(NavigateToMenuSelection);
            NavigateToBoxCommand = ReactiveCommand.Create(NavigateToBox);
            NavigateTo478Command = ReactiveCommand.Create(NavigateToCalm);
            NavigateToDeepCommand = ReactiveCommand.Create(NavigateToDeep);
        }
        private readonly ViewModelBase[] Pages =
        {
            new BreatheMainViewModel(), // Main page for box
            new BreatheViewModel(), // box 
            new BreatheSelectionViewModel(), // menu
            new CalmBreathingMainViewModel(), // main page for 478
            new CalmBreathingViewModel(), // 478
            new DeepBreathingMainViewModel(), // menu page for deep breathing
            new DeepBreathingViewModel() // deep breathing page
        };
        private ViewModelBase _CurrentPage;
        public ViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }
        public ICommand NavigateNextCommand { get; }
        public ICommand NavigatePreviousCommand { get; }
        public ICommand NavigateToMenu { get; }
        public ICommand NavigateToBoxCommand { get; }
        public ICommand NavigateTo478Command { get; }
        public ICommand NavigateToDeepCommand { get; }
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
        private void NavigateToMenuSelection()
        {
            CurrentPage = Pages[2];
        }
        private void NavigateToBox()
        {
            CurrentPage = Pages[0];
        }
        private void NavigateToCalm()
        {
            CurrentPage = Pages[3];
        }
        private void NavigateToDeep()
        {
            CurrentPage = Pages[5];
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
