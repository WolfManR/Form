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
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
