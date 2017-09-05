using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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

        public bool Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Save path missing", nameof(fileName));
            }

            var saveHandler = new StorageHandler
            {
                Items = Items.ToList(),
                FileName = fileName
            };

            return saveHandler.Save();
        }


        public void Restore(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Open path missing", nameof(fileName));
            }

            var saveHandler = new StorageHandler();
            Items = new ObservableCollection<Job>(saveHandler.Restore(fileName).Items); 

        }

        public void Clear()
        {
            Items = new ObservableCollection<Job>();
        }
    }
}