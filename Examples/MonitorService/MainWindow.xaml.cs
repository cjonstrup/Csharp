using System.Windows;

namespace MonitorService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = _viewModel = new ViewModel();
            //_viewModel.Services.Add(new ExampleProvider() {Alert = new SmsAlert() });
            //_viewModel.Services.Add(new MysqlProvider() { Alert = new SmsAlert() });
        }
    }
}
