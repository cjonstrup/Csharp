using Microsoft.Practices.Unity;

namespace MonitorService
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
        public IUnityContainer Container => _container ?? (_container = new UnityContainer());

        public void Register()
        {
            //Container.RegisterInstance<IGps>(new GarminGTU10Provider());
            //Container.RegisterInstance(new GpsConfig());
            Container.RegisterInstance(Container);
            Container.RegisterInstance(Container as UnityContainer);
        }
    }
}