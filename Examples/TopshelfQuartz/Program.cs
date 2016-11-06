using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;
using Topshelf.Unity;

namespace TopshelfQuartz
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
        //readonly IScheduler _scheduler = StdSchedulerFactory.GetDefaultScheduler();

        [Dependency]
        public IUnityContainer Container { set; get; }

        [Dependency]
        public IScheduler Scheduler { set; get; }

        private MyService _setup;
        public MyService Setup
        {
            get { return _setup ?? (_setup = Init()); }
        }

        public MyService Init()
        {



            //Scheduler.ScheduleJob(
            //                     new JobDetailImpl("TestJob", typeof(HelloJob)),
            //                     new CalendarIntervalTriggerImpl("TestTrigger", IntervalUnit.Second, 5));

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();




            // Tell quartz to schedule the job using our trigger
            Scheduler.ScheduleJob(job, trigger);

            return this;

        }

        public void Start()
        {
           Scheduler.Start();
        }

        public void Stop()
        {
           Scheduler.Shutdown();
        }
    }

    public class HelloJob : IJob
    {
        [Dependency]
        public UnityContainer Container { set; get; }

        public void Execute(IJobExecutionContext context)
        {

            var f = Container.Resolve<IScheduler>();
            Console.WriteLine("Greetings from HelloJob! : " + f.SchedulerName);
        }
    }
}
