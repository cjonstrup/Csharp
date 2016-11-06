using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonitorService.Alert;

namespace MonitorService.Services.Database
{
    public class MysqlProvider : BaseService, IService
    {
        private bool _online;

        public void Start()
        {
            //throw new NotImplementedException();
        }

        public void Stop()
        {
            //throw new NotImplementedException();
        }

        public string Name
        {
            get { return "Mysql"; }
        }

        public bool Online
        {
            get
            {
                return _online;
            }
            private set
            {
                _online = value;
                OnPropertyChanged();
            }
        }

        public bool Active { get; set; }
        public DateTime LastRun { get; }
        public DateTime LastError { get; }
        public int TotalRun { get; }
        public int TotalError { get; }
        public int ExecutionTime { get; }
        public IAlert Alert { get; set; }


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
