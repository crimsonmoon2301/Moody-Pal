using Avalonia.Interactivity;
using kursadarbs_reactiveUI.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Timers;
using Avalonia.Media;
using Avalonia.Platform;
using LibVLCSharp.Shared;
using System.IO;



namespace kursadarbs_reactiveUI.ViewModels
{
    public class FocusViewModel : ViewModelBase
    {
        private Timer _timer;
        private string _remainingTimeText = "01:00";
        private TimeSpan _remainingTime = TimeSpan.FromMinutes(1);
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _mediaPlayer;
        public string RemainingTime
        {
            get => _remainingTimeText;
            set => this.RaiseAndSetIfChanged(ref _remainingTimeText, value);
        }
        public ICommand AddTimeCommand { get; }
        public ICommand RemoveTimeCommand { get; }

        public ICommand StartTimerCommand { get; }
        public ICommand PauseTimerCommand { get; }
        public ICommand StopTimerCommand { get; }
        public FocusViewModel()
        {
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            _timer = new Timer();
            //_timer.AutoReset = true;
            AddTimeCommand = ReactiveCommand.Create(AddTime);
            RemoveTimeCommand = ReactiveCommand.Create(RemoveTime);
            StartTimerCommand = ReactiveCommand.Create(StartTimer);
            PauseTimerCommand = ReactiveCommand.Create(PauseTimer);
            StopTimerCommand = ReactiveCommand.Create(StopTimer);
            _timer.Interval = 1000;
            _timer.Elapsed += OnTimerElapsed;

            //

            UpdateTimeText();
        }
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            if (_remainingTime.TotalNanoseconds <= 0)
            {
                StopTimer();
                PlayEndSound();
                return;
            }
            _remainingTime -= TimeSpan.FromSeconds(1);
            UpdateTimeText();
        }
        public void AddTime()
        {
            _remainingTime += TimeSpan.FromMinutes(1);
            UpdateTimeText();
        }
        private void AddCurrentTime(TimeSpan time)
        {

        }
        public void RemoveTime()
        {
            if (_remainingTime.TotalMinutes <= 1)
            {
                return;
            }
            _remainingTime -= TimeSpan.FromMinutes(1);
            UpdateTimeText();
        }
        public void StartTimer()
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
            }
        }
        public void PauseTimer()
        {
            _timer.Stop();
        }
        public void StopTimer()
        {
            _timer.Stop();
            _remainingTime = TimeSpan.FromMinutes(1);
            UpdateTimeText();
        }
        private void UpdateTimeText()
        {
            RemainingTime = FormatTime(_remainingTime);
        }
        //public FocusViewModel(TimerSession timerSession)
        //{
        //    _timersession = timerSession;
        //    _remainingTime = FormatTime(_timersession.Remaining);

        //    _timersession = 
        //}
        private void PlayEndSound()
        {
            using var media = new Media(
                _libVLC,
                new Uri(Path.GetFullPath("Assets/sounds/timer_end.mp3"))
            );

            _mediaPlayer.Play(media);
        }
        public string FormatTime(TimeSpan time)
        {
            return time.ToString(@"mm\:ss");
        }
    }
}
