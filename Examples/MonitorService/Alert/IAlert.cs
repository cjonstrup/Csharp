namespace MonitorService.Alert
{
    public interface IAlert
    {
        int MinErrors { set; }
        int NumErrors { set; }
        int MaxAlerts { set; }
        string Subject { set; }
        string Body { set; }

        void Send();
    }
}