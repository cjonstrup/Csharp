using System;
using Nancy.Hosting.Self;

namespace WebServer
{
    public class NancySelfHost
    {
        private NancyHost m_nancyHost;
        private const string Url = "http://localhost:5000";

        public void Start()
        {
            m_nancyHost = new NancyHost(new Uri(Url));
            m_nancyHost.Start();
            Console.WriteLine(Url);
        }

        public void Stop()
        {
            m_nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
