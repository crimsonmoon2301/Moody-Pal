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
        private bool _isRunning;
        private int _step = 0;
        public async void StartTimer()
        {
            if (_isRunning)
            {
                return;
            }

            int totalDurationMs = 64_000;   // 1 minute
            int stepMs = 4_000;             // 5 seconds
            int elapsed = 0;
            _isRunning = true;

            
            while (_isRunning && elapsed < totalDurationMs)
            {
                if (_step == 0)
                {
                    BreatheText = Assets.Resources.BreatheIn;
                    //await Task.Delay(4000);
                    //ShowFirst = true;
                }
                else if (_step == 1)
                {
                    BreatheText = Assets.Resources.BreatheHold;
                    //await Task.Delay(7000);
                }
                else if (_step == 2)
                {
                    BreatheText = Assets.Resources.BreatheOut;
                    //ShowFirst = false;
                    //await Task.Delay(8000);
                }
                else
                {
                    BreatheText = Assets.Resources.BreatheHold;
                }

                _step++;
                if (_step > 3)
                {
                    _step = 0;
                }

                await Task.Delay(stepMs);
                elapsed += stepMs;
            }
            _isRunning = false;
            BreatheText = Assets.Resources.BreatheDone; 
        }
        public void StopTimer()
        {
            _isRunning = false;
        }
    }
}
