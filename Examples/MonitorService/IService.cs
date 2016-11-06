using System;
using MonitorService.Alert;

namespace MonitorService
{
    public interface IService
    {
        void Start();
        void Stop();

        string Name { get; }
        bool Online { get; }
        bool Active { get; set; }

        DateTime LastRun { get; }
        DateTime LastError { get; }

        int TotalRun { get; }
        int TotalError { get; }

        int ExecutionTime { get; }

        IAlert Alert { get; set; }

    }
}