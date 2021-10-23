using System.Windows;
using Form.ViewModels;
using Form.Views;

namespace Form
{
    public partial class App : Application
    {
        private static readonly MainVM MainVM = new();
        public App()
        {
            var mainWindow = new MainWindow()
            {
                DataContext = MainVM,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };

            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
