using System.Collections.ObjectModel;
using System.Windows;

namespace Form
{
    public partial class InfoPanel : Window
    {
        public InfoPanel()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow { get; set; }

        public ObservableCollection<IconData> Icons { get; set; } = new();

        private void AddIcon_Click(object sender, RoutedEventArgs e)
        {
            Icons.Add(new(IconGeometryBox.Text, IconNameBox.Text));
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IconGeometryBox.Text = null;
            IconNameBox.Text = null;
        }
    }

    public record IconData(string Geometry, string Name);
}
