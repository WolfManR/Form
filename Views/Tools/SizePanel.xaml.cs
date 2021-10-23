using System.Windows;
using System.Windows.Input;

namespace Form.Views.Tools
{
    public partial class SizePanel : Window
    {
        public SizePanel() => InitializeComponent();

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
