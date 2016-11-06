using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using MonitorService.Alert;
using MonitorService.Services.Database;
using Timer = System.Timers.Timer;

namespace MonitorService.Services
{
    public class ExampleProvider : BaseService, IService
    {
        private Timer _timer;
        private readonly BackgroundWorker _worker;

        public ExampleProvider()
        {
            _worker = new BackgroundWorker { WorkerSupportsCancellation = true };
            _worker.DoWork += _worker_DoWork;
            
            _timer = new Timer(2000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var f = new Ping();
                var reply = f.Send("8.8.8.8");
                if (reply.Status == IPStatus.Success)
                {
                    Online = true;
                }
                else
                {
                    //Online = false;
                    throw new Exception("Ping error");
                }
            }
            catch (Exception ex)
            {
                Online = false;
                LastError = DateTime.Now;
                TotalError = TotalError + 1;

                Alert.Subject = ex.Message;
                Alert.NumErrors = TotalError;
            }

            Random r = new Random();
            int x = r.Next(15, 90);
            Thread.Sleep(x);
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;
            ExecutionTime = (int)elapsedMs;
            LastRun = DateTime.Now;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_worker.IsBusy)
            {
                TotalRun = TotalRun + 1;
                _worker.RunWorkerAsync();
            }
        }

        public string Name
        {
            get { return "Example"; }
        }

        private bool _online;
        public bool Online
        {
            get { return _online; }
            private set
            {
                _online = value;
                OnPropertyChanged();
            }
        }

        public bool Active
        {
            get { return _timer.Enabled; }
            set
            {
                if (value)
                {
                    _timer.Start();
                }
                else
                {
                    _timer.Stop();
                }

                OnPropertyChanged();
            }
        }

        private DateTime _lastRun;
        public DateTime LastRun
        {
            get { return _lastRun; }
            private set
            {
                _lastRun = value;
                OnPropertyChanged();
            }
        }

        private DateTime _lastError;
        public DateTime LastError
        {
            get
            {
                return _lastError;
            }
            private set
            {
                _lastError = value;
                OnPropertyChanged();
            }
        }



        public int TotalRun
        {
            get
            {
                return _totalRun;
            }
            private set
            {
                _totalRun = value;
                OnPropertyChanged();
            }
        }

        public int TotalError
        {
            get { return _totalError; }
            private set
            {
                _totalError = value;
                OnPropertyChanged();
            }
        }

        private int _executionTime;
        private int _totalError;
        private int _totalRun;

        public int ExecutionTime
        {
            get
            {
                return _executionTime;
            }
            private set
            {
                _executionTime = value;
                OnPropertyChanged();
            }
        }

        public IAlert Alert { get; set; }


        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}