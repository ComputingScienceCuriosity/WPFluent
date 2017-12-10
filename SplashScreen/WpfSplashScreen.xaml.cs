
using System.Windows;

namespace WPFluent.SplashScreen
{
    /// <summary>
    /// Logique d'interaction pour WpfSplashScreen.xaml
    /// </summary>
    public partial class WpfSplashScreen : Window
    { 
        public WpfSplashScreen()
        {
            InitializeComponent();
        }

        public void AppLoadingCompleted()
        {
            Dispatcher.InvokeShutdown();
        }
    }
}
