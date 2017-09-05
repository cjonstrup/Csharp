using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

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
            //_vm.Items.Add(new Job() { Name = "WP-1402" });
            //_vm.Items.Add(new Job() { Name = "Mads" });
            //_vm.Items.Add(new Job() { Name = "Dan" });
            //_vm.Items.Add(new Job() { Name = "Brian" });
            //_vm.Items.Add(new Job() { Name = "Lars" });
            //_vm.Items.Add(new Job() { Name = "Michael" });
            //_vm.Items.Add(new Job() { Name = "Internal" });
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

        private void CommandManager_OnPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Please confirm.", MessageBoxButton.YesNo, MessageBoxImage.Information,MessageBoxResult.No) != MessageBoxResult.Yes)
                {
                    // Cancel Delete.
                    e.Handled = true;
                }
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {

            var saveFileDialog =
                new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    FileName = "tracker-" + DateTime.Now.ToString("yyyy-MM-dd"),
                    DefaultExt = ".json",
                    Title = "Gem TimeTracker",
                    Filter = "Json documents (.json)|*.json"
                };

            if (saveFileDialog.ShowDialog() == true)
              _vm.Save(saveFileDialog.FileName);
        }

        private void MenuItemOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DefaultExt = ".json",
                Title = "Åben TimeTracker",
                Filter = "Json documents (.json)|*.json"
            };

            if (openFileDialog.ShowDialog() == true)
                _vm.Restore(openFileDialog.FileName);

        }

        private void MenuItemClear_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _vm.Clear();
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //var log = new JiraWorkLog();

            String data = "{\"started\":\"2017-09-05T23:10:18.932+0200\",\"timeSpent\":\"30m\",\"comment\":\"timetracker post 2\"}";

            await PostJsonAsync("ljljljl", data);
        }

        public async Task<HttpResponseMessage> PostJsonAsync(string apiUrl, string messageBody)
        {
            HttpResponseMessage response;
            if (String.IsNullOrEmpty(apiUrl))
            {
                throw new ApplicationException("apiUrl required");
            }

            using (var httpClient = new HttpClient())
            {
                var request = new StringContent(messageBody);
                request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var credentials = Encoding.ASCII.GetBytes("x:x");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                response = await httpClient.PostAsync(new Uri("https://winkas.atlassian.net/rest/api/latest/issue/WP-1884/worklog"), request);
                Debug.WriteLine(response);
            }

            return response;
        }
    }
}
