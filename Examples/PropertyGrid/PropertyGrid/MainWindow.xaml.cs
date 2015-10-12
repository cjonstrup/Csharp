using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PropertyGrid.Annotations;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace PropertyGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Test ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            DataContext = ViewModel = new Test();

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            propertyGrid.SelectedObject = new Test();
            propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
        }

        private void PropertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            var grid = s as System.Windows.Forms.PropertyGrid;

          
               // ViewModel.GetType().GetProperty(e.ChangedItem.ToString()).SetValue(ViewModel, e.ChangedItem.Value, null);

        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Perform the hit test against a given portion of the visual object tree.
            HitTestResult result = VisualTreeHelper.HitTest(this, pt);

            if (result != null)
            {
                if (result.VisualHit.GetType() == typeof (TextBlock))
                {
                    propertyGrid.SelectedObject = result.VisualHit;
                } 
                
                // Perform action on hit visual object.
                
            }
        }
    }




    public class Test : INotifyPropertyChanged
    {
        private string _tagName;

        public string TagName
        {
            get { return _tagName; }
            set
            {
                if (value == _tagName) return;
                _tagName = value;
                OnPropertyChanged();
            }
        }

        [TypeConverter(typeof(DrinkerClassConverter))]
        public bool Enabled { get; set; }
        public double Value { get; set; }

        public Color Background { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class DrinkerClassConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture,
        object value,
        Type destType)
        {
            return (bool)value ?
            "Yes" : "Yes, of course";
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture,
        object value)
        {
            return (string)value == "Yes";
        }
    }

  
}
