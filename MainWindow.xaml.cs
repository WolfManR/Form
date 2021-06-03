using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Form
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow() => InitializeComponent();

        private double _windowHeight = 200;
        public double WindowHeight
        {
            get => _windowHeight;
            set
            {
                if(Set(ref _windowHeight, value))
                    RaisePropertyChanged(nameof(WindowSize));
            }
        }

        private double _windowWidth = 200;
        public double WindowWidth
        {
            get => _windowWidth;
            set
            {
                if(Set(ref _windowWidth, value))
                    RaisePropertyChanged(nameof(WindowSize));
            }
        }

        private Thickness _thickness = new Thickness(0,0,0,0);
        public Thickness Thickness { get => _thickness; set => Set(ref _thickness, value); }

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
            DragMove();
        }
    }
}
