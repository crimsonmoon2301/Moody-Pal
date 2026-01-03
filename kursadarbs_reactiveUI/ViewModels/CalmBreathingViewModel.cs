using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI.ViewModels
{
    internal class CalmBreathingViewModel : ViewModelBase
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
        public int elapsed = 0;
        public async void StartTimer()
        {
            if (_isRunning)
            {
                return;
            }

            int totalDurationMs = 64_000;   // 1 minute
            elapsed = 0;
            
            _isRunning = true;


            while (_isRunning && elapsed < totalDurationMs)
            {
                int step1 = 0;
                int step2 = 0;
                int step3 = 0;

                if (_step == 0)
                {
                    BreatheText = Assets.Resources.BreatheIn;
                    await Task.Delay(4000);
                    step1 = 4000;
                    //ShowFirst = true;
                }
                else if (_step == 1)
                {
                    BreatheText = Assets.Resources.BreatheHold;
                    await Task.Delay(7000);
                    step2 = 7000;
                }
                else if (_step == 2)
                {
                    BreatheText = Assets.Resources.BreatheOut;
                    //ShowFirst = false;
                    await Task.Delay(8000);
                    step3 = 8000;
                }
                else
                {
                    BreatheText = Assets.Resources.BreatheHold;
                    //ShowFirst = false;
                    await Task.Delay(4000);
                }

                await Task.Delay(1000);
                _step++;
                if (_step > 3)
                {
                    _step = 0;
                }

                int cycle = step1 + step2 + step3;
                //await Task.Delay(stepMs);
                elapsed += cycle;
            }
            _isRunning = false;
            BreatheText = "All done, press stop to end.";
        }
        public void StopTimer()
        {
            _isRunning = false;
        }
    }
}
