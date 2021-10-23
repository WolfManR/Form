using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Form.Models;
using Thundire.MVVM.WPF.Observable.Base;

namespace Form.ViewModels.Tools
{
    public class SizePanelVM : NotifyBase
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

        public Theme Theme { get => _theme; set => Set(ref _theme, value); }
        public double WindowHeight { get => _windowHeight; set => Set(ref _windowHeight, value).DoOnSuccess(state => RaisePropertyChanged(nameof(WindowSize))); }
        public double WindowWidth { get => _windowWidth; set => Set(ref _windowWidth, value).DoOnSuccess(state => RaisePropertyChanged(nameof(WindowSize))); }
        public CornerRadius CornerRadius { get => _cornerRadius; set => Set(ref _cornerRadius, value); }

        public string WindowSize => $"{WindowHeight:####} x {WindowWidth:####}";

        public ICommand SwitchThemeCommand { get; }

        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            Theme = _isInDarkMode ? Light : Dark;
            _isInDarkMode = !_isInDarkMode;
        }
    }
}