using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace TimeLocker
{
    public class Job : BaseService
    {
        private Timer _timer;
        private DateTime _start;
        private TimeSpan _elapsedTimeSpan;

        private int _todayCount;
        private bool _started;

        public Job()
        {
            WorkLog = new ObservableCollection<Log>();
        }

        public ObservableCollection<Log> WorkLog { get; set; }

        public string Name { get; set; }

        public void Start()
        {
            Started = true;
             _start = DateTime.Now;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        public bool Started
        {
            get => _started;
            set
            {
                _started = value;
                OnPropertyChanged();
            }
        }

        public int TodayCount
        {
            get => _todayCount;
            set
            {
                _todayCount = value; 
                OnPropertyChanged();
            }
        }

        public TimeSpan ElapsedTimeSpan
        {
            get => _elapsedTimeSpan;
            set
            {
                _elapsedTimeSpan = value;
                OnPropertyChanged();
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ElapsedTimeSpan = DateTime.Now.Subtract(_start);
        }

        public void Stop()
        {
            if (_timer != null && !_timer.Enabled)
            {
                return;
            }

            _timer?.Stop();
            if (Started)
            {
                WorkLog.Add(new Log() { Start = _start, Slut = DateTime.Now });
                TodayCount = WorkLog.Count;
                Started = false;
            }
        }
    }
}