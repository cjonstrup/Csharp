using System.Collections.ObjectModel;
using System.Windows;

namespace MonitorService
{
    public class ViewModel : DependencyObject
    {
        public ViewModel()
        {
            Services = new ObservableCollection<IService>();
        }

        public static readonly DependencyProperty ServicesProperty = DependencyProperty.Register(
            "Services", typeof(ObservableCollection<IService>), typeof(ViewModel), new PropertyMetadata(default(ObservableCollection<IService>)));

        public ObservableCollection<IService> Services
        {
            get { return (ObservableCollection<IService>) GetValue(ServicesProperty); }
            set { SetValue(ServicesProperty, value); }
        }

    }
}