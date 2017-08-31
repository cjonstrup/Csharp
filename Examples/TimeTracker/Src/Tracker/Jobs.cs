﻿
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace TimeLocker
{
    public class Job : BaseService
    {
        private System.Timers.Timer _timer;
        private DateTime _start;
        private TimeSpan _elapsedTimeSpan;
        private bool _started;
        private int _todayCount;

        public Job()
        {
            WorkLog = new ObservableCollection<Log>();
        }

        public ObservableCollection<Log> WorkLog { get; set; }

        public string Name { get; set; }

        public void Start()
        {
             _started = true;
             _start = DateTime.Now;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }


        public int TodayCount
        {
            get
            {
                return _todayCount;
            }
            set
            {
                _todayCount = value; 
                OnPropertyChanged();
            }
        }


        public TimeSpan ElapsedTimeSpan
        {
            get { return _elapsedTimeSpan; }
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
            if (_started)
            {
                WorkLog.Add(new Log() { Start = _start, Slut = DateTime.Now });
                TodayCount = WorkLog.Count;
            }
        }
    }

    public class BaseService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}