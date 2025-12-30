using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Avalonia.Interactivity;

namespace kursadarbs_reactiveUI.ViewModels
{
    internal class SplashViewModel : ViewModelBase
    {
        public string ProgramName
        {
            get => _programName;
            set { this.RaiseAndSetIfChanged(ref _programName, value); }
        }
        private string _programName = "Moody Pal";
        public string StartupMessage
        {
            get => _startupMessage;
            set { this.RaiseAndSetIfChanged(ref _startupMessage, value); }
        }
        private string _startupMessage = "Starting application...";
    
    }
}
