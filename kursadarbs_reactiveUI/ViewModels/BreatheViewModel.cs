using ReactiveUI;
using System.Reactive.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Disposables;
using kursadarbs_reactiveUI.Assets;
using System.Globalization;


namespace kursadarbs_reactiveUI.ViewModels
{
    public class BreatheViewModel : ViewModelBase
    {
        public string BreatheText
        {
            get => _breatheText;
            set { this.RaiseAndSetIfChanged(ref _breatheText, value); }
        }
        private string _breatheText = "Inhale...";
        private bool _showFirst = true;
        public bool ShowFirst
        {
            get { return _showFirst; }
            set { this.RaiseAndSetIfChanged(ref _showFirst, value); }
        }
        public async void StartTimer()
        {
            int totalDurationMs = 60_000;   // 1 minute
            int stepMs = 5_000;             // 5 seconds
            int elapsed = 0;

           
            while (elapsed < totalDurationMs)
            {
                if (ShowFirst)
                {
                    BreatheText = Assets.Resources.BreatheIn;
                    ShowFirst = true;
                }
                else
                {
                    BreatheText = Assets.Resources.BreatheOut;
                    ShowFirst = false;
                }

                ShowFirst = !ShowFirst;

                await Task.Delay(stepMs);
                elapsed += stepMs;
            }
        }
    }
}
