using ConsoleApplication1.Provider.MyLogger;
using ConsoleApplication1.Provider.SmsService;
using Microsoft.Practices.Unity;
using System;
using System.Timers;
using Topshelf;
using Topshelf.Unity;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Bootstrapper().Container;

            HostFactory.Run(configurator =>
            {
                configurator.UseUnityContainer(container);

                configurator.Service<IService>(service =>
                {
                    service.ConstructUsingUnityContainer();

                    service.WhenStarted(x => x.Start());
                    service.WhenStopped(x => x.Stop());
                });

                configurator.RunAsLocalSystem();

                configurator.EnableServiceRecovery(sr => sr.RestartService(1));

                configurator.SetDisplayName("xxx");
                configurator.SetDescription("xxx");
                configurator.SetServiceName("xxx");


                configurator.StartAutomatically();

            });
        }
    }

 
    public interface IService
    {
        void Start();
        void Stop();
    }

    public class MyService : IService
    {
        readonly Timer _timer;

        public MyService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("It is {0} and all is well", DateTime.Now);
            //Logger.Error("MyService error");
        }

        [Dependency]
        public ISms SmsService { set; get; }

        [Dependency]
        public ILog Logger { set; get; }
        

        [Dependency]
        public UnityContainer Container { set; get; }

        public void Start()
        {
            _timer.Start();
            Logger.Info("MyService started");
        }

        public void Stop()
        {
            _timer.Stop();
            Logger.Info("MyService stoped");
        }
    }
}
