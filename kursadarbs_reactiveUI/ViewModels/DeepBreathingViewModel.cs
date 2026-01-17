using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursadarbs_reactiveUI.ViewModels
{
    internal class DeepBreathingViewModel : ViewModelBase
    {
        public string BreatheText
        {
            get => _breatheText;
            set { this.RaiseAndSetIfChanged(ref _breatheText, value); }
        }
        private string _breatheText = "Inhale deeply through nose...";
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

            int totalDurationMs = 61_000;
            int step = 3000;
            int tick = 1000;  // 1 minute
            int elapsed = 0;

            _isRunning = true;


            while (_isRunning && elapsed < totalDurationMs)
            {
                if (_step == 0)
                {
                    BreatheText = Assets.Resources.BreatheIn;
                    await Task.Delay(step);
                    
                    //ShowFirst = true;
                }
                else if (_step == 1)
                {
                    BreatheText = Assets.Resources.DeepBreathing5;
                    await Task.Delay(tick);
                    elapsed += tick;
                   
                }
                else if (_step == 2)
                {
                    BreatheText = Assets.Resources.DeepBreathing4;
                    //ShowFirst = false;
                    await Task.Delay(tick);
                    elapsed += tick;
                }
                else if (_step == 3)
                {
                    BreatheText = Assets.Resources.DeepBreathing3;
                    //ShowFirst = false;
                    await Task.Delay(tick);
                    elapsed += tick;
                }
                else if (_step == 4)
                {
                    BreatheText = Assets.Resources.DeepBreathing2;
                    await Task.Delay(tick);
                    elapsed += tick;
                }
                else if (_step == 5)
                {
                    BreatheText = Assets.Resources.DeepBreathing1;
                    await Task.Delay(tick);
                    elapsed += tick;
                }
                else
                {
                    BreatheText = Assets.Resources.DeepBreathingExhale;
                    await Task.Delay(step);
                    elapsed += step;
                }
                _step++;
                if (_step > 6)
                {
                    _step = 0;
                }
                //await Task.Delay(stepMs);
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
