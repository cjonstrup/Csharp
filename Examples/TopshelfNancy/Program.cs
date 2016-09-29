using Topshelf;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseLinuxIfAvailable();

                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("XXX Service");
                x.SetDisplayName("XXX Service");
                x.SetServiceName("XXX-Service");
            });
        }
    }
}
