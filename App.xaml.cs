using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Windows.Media;
using OSVersionInfo;
using WPFluent.Composition;
using WPFluent.Views;

namespace WPFluent
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Startup += (sender, args) =>
            {
                LaunchMainWindow();
            };
        }

        private void LaunchMainWindow()
        {
            var fluentMainWindow = Activator.CreateInstance<MainWindow>();

            fluentMainWindow.DataContext = Activator.CreateInstance<ViewModels.MainViewModel>();

            fluentMainWindow.Show();
        }
    }
}
