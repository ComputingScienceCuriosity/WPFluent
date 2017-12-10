
using System.Windows;
using System.Windows.Input;
using WPFluent.Commands;

namespace WPFluent.ViewModels
{
    public class MainViewModel
    {
        public ICommand QuitterCommand { get; private set; }

        public ICommand ToggleCommand { get; private set; }

        public ICommand MinimizeCommand { get; private set; }

        public MainViewModel()
	    {
            QuitterCommand                                  = new RelayCommand(() =>
            {
                Application.Current.MainWindow.Close();
            });

	        ToggleCommand                                   = new RelayCommand(() =>
            {
              Application.Current.MainWindow.WindowState    = Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;   
            });

	        MinimizeCommand                                 = new RelayCommand(() =>
            {
                 Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });
        }
    }
}
