using System;
using System.Threading;
using System.Windows.Threading;
using WPFluent.SplashScreen;

namespace WPFluent
{
    public sealed class ApplicationEntry
    { 
        #region Variables

        private static Thread uiThread = null;

        private static WpfSplashScreen applicationSplashScreen = null;

        #endregion
        [STAThreadAttribute]
        public static void Main()
        {
            uiThread = new Thread(DisplayApplicationSplashScreen);

            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.IsBackground = true;
            uiThread.Name = "CoreComponents.WPF Demo Thread";

            uiThread.Start();

            // You can put your init logique here : 
            Thread.Sleep(4000);

            applicationSplashScreen.Dispatcher.InvokeShutdown();
            applicationSplashScreen = null;

            var application = new App();
            application.InitializeComponent();
            application.Run();
        }


        private static void DisplayApplicationSplashScreen()
        {
            applicationSplashScreen = new WpfSplashScreen();
            applicationSplashScreen.Show();
            Dispatcher.Run();
        }
    }
}
