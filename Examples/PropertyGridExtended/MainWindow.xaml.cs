using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PropertyGridExtended.Annotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace PropertyGridExtended
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Demo ViewModel;

        public MainWindow()
        {

            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModel = new Demo();
        }
    }

    public class Demo
    {

        [Category("Firma")]
        public string TagName { get; set; }

        [Category("Firma")]
        public int Value { get; set; }

        [Category("Firma")]
        public bool Enabled { get; set; }

        [Category("Firma")]
        public Color BackGround { get; set; }


    }
}
