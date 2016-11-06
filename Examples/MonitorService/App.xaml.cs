using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using MonitorService.Alert;
using MonitorService.Services;
using MonitorService.Services.Database;

namespace MonitorService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));

            var commandLineArgs = Environment.GetCommandLineArgs();

            var container = new Bootstrapper().Container;

            var viewModel = new ViewModel();

            //add services
            viewModel.Services.Add(new ExampleProvider()
            {
                Alert = new SpeechAlert() { MinErrors = 3, MaxAlerts = 4}
            });




            if (commandLineArgs.Length > 1 && commandLineArgs[1].Equals("-service"))
            {
                foreach (var service in viewModel.Services)
                {
                    service.Start();
                }
            }
            else
            {
                var mainWindow = container.Resolve<MainWindow>();
                mainWindow.DataContext = viewModel;
                mainWindow.Show();
            }
        }
    }
}
