using ConsoleApplication1.Provider.SmsService;
using ConsoleApplication1.Provider.SmsService.Mobility;
using Microsoft.Practices.Unity;


namespace ConsoleApplication1
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
            Container.RegisterInstance<ISms>(new MobilityProvider());
            Container.RegisterInstance<ISms>("Mock", new MobilityProviderMock());
            Container.RegisterInstance(Container);
            Container.RegisterInstance(Container as UnityContainer);


            Container.RegisterInstance<IService>(Container.BuildUp(new MyService()));

        }
    }
}
