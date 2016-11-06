using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Unity;
using TopshelfQuartz;

namespace TopshelfQuartz
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            Register();
        }

        public Bootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        private IUnityContainer _container;
        public IUnityContainer Container
        {
            get { return _container ?? (_container = new UnityContainer()); }
        }

        public void Register()
        {
            //Container.RegisterInstance<ISms>(new MobilityProvider());
            //Container.RegisterInstance<ISms>("Mock", new MobilityProviderMock());

            //Container.RegisterInstance<ILog>(new NLogProvider());

            Container.AddNewExtension<QuartzUnityExtension>();

            Container.RegisterType<ISchedulerFactory, UnitySchedulerFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IScheduler>(new InjectionFactory(c => c.Resolve<ISchedulerFactory>().GetScheduler()));

            Container.RegisterInstance(Container);
            Container.RegisterInstance(Container as UnityContainer);

            Container.RegisterInstance<IService>(Container.BuildUp(new MyService()).Setup);

        }
    }
}
