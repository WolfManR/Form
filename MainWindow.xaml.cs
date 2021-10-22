using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Form
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _windowHeight = 200;
        private double _windowWidth = 200;
        private CornerRadius _cornerRadius = new(0);
        private bool _isInDarkMode = true;
        private Theme _theme = Dark;

        private static readonly Theme Light = new()
        {
            Background = new SolidColorBrush(Colors.White) { Opacity = .2 },
            BorderBrush = new SolidColorBrush(Colors.Orange) { Opacity = .6 },
            Foreground = new SolidColorBrush(Colors.DarkOrange),
        };

        private static readonly Theme Dark = new()
        {
            Background = new SolidColorBrush(Colors.Black) { Opacity = .1 },
            BorderBrush = new SolidColorBrush(Colors.DodgerBlue) { Opacity = .6 },
            Foreground = new SolidColorBrush(Colors.WhiteSmoke),
        };


        public MainWindow() => InitializeComponent();

        public double WindowHeight
        {
            get => _windowHeight;
            set
            {
                if(Set(ref _windowHeight, value))
                    RaisePropertyChanged(nameof(WindowSize));
            }
        }

        public double WindowWidth
        {
            get => _windowWidth;
            set
            {
                if(Set(ref _windowWidth, value))
                    RaisePropertyChanged(nameof(WindowSize));
            }
        }

        public Theme Theme { get => _theme; set => Set(ref _theme, value); } 
        public CornerRadius CornerRadius { get => _cornerRadius; set => Set(ref _cornerRadius, value); }
        public string WindowSize => $"{WindowHeight:####} x {WindowWidth:####}";
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            Theme = _isInDarkMode ? Light : Dark;
            _isInDarkMode = !_isInDarkMode;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ControlPanel_Click(object sender, RoutedEventArgs e)
        {
            var panel = new InfoPanel();
            panel.MainWindow = this;
            panel.Owner = this;
            panel.Show();
        }
    }

    public class Theme
    {
        public Brush Background { get; init; }
        public Brush BorderBrush { get; init; }
        public Brush Foreground { get; init; }
    }
}
