using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace TimeLocker
{
    public class ViewModel : DependencyObject
    {
        public ViewModel()
        {
            Items = new ObservableCollection<Job>();
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", typeof(ObservableCollection<Job>), typeof(ViewModel), new PropertyMetadata(default(ObservableCollection<Job>)));

        public ObservableCollection<Job> Items
        {
            get { return (ObservableCollection<Job>) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedJobProperty = DependencyProperty.Register(
            "SelectedJob", typeof(Job), typeof(ViewModel), new PropertyMetadata(default(Job),OnJobChanged));

        private static void OnJobChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        public Job SelectedJob
        {
            get { return (Job) GetValue(SelectedJobProperty); }
            set { SetValue(SelectedJobProperty, value); }
        }
    }
}