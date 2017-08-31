using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _vm = new ViewModel();
            _vm.Items.Add(new Job() { Name = "WP-1402" });
            _vm.Items.Add(new Job() { Name = "Mads" });
            _vm.Items.Add(new Job() { Name = "Dan" });
            _vm.Items.Add(new Job() { Name = "Brian" });
            _vm.Items.Add(new Job() { Name = "Lars" });
            _vm.Items.Add(new Job() { Name = "Michael" });
            _vm.Items.Add(new Job() { Name = "Internal" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var job in _vm.Items)
            {
                job.Stop();
            }

            _vm.SelectedJob?.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _vm.SelectedJob?.Stop();
        }
    }
}
