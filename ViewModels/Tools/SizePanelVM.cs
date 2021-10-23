using Form.Models;
using Form.Views.Tools;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Thundire.MVVM.WPF.Commands.Relay;
using Thundire.MVVM.WPF.Observable.Base;

namespace Form.ViewModels.Tools
{
    public class SizePanelVM : NotifyBase
    {
        private double _windowHeight;
        private double _windowWidth;
        private CornerRadius _cornerRadius;
        private bool _isInDarkMode;
        private Theme _theme;

        private readonly Theme _light;
        private readonly Theme _dark;

        public SizePanelVM()
        {
            _cornerRadius = new(0);
            _isInDarkMode = true;
            _windowHeight = 200;
            _windowWidth = 200;

            _light = new()
            {
                Background = new SolidColorBrush(Colors.White) { Opacity = .2 },
                BorderBrush = new SolidColorBrush(Colors.Orange) { Opacity = .6 },
                Foreground = new SolidColorBrush(Colors.DarkOrange),
            };

            _dark = new()
            {
                Background = new SolidColorBrush(Colors.Black) { Opacity = .1 },
                BorderBrush = new SolidColorBrush(Colors.DodgerBlue) { Opacity = .6 },
                Foreground = new SolidColorBrush(Colors.WhiteSmoke),
            };

            _theme = _dark;

            SwitchThemeCommand = new RelayCommand(SwitchTheme, () => _isSizePanelOpen);
            OpenSizePanelCommand = new RelayCommand(OpenSizePanel, () => !_isSizePanelOpen);
            CloseSizePanelCommand = new RelayCommand(CloseSizePanel, () => _isSizePanelOpen);
        }

        public SizePanel SizePanel { get; set; }

        private bool _isSizePanelOpen;
        public bool IsSizePanelOpen { get => _isSizePanelOpen; set => Set(ref _isSizePanelOpen, value); }
        public Theme Theme { get => _theme; set => Set(ref _theme, value); }
        public double WindowHeight { get => _windowHeight; set => Set(ref _windowHeight, value).DoOnSuccess(state => RaisePropertyChanged(nameof(WindowSize))); }
        public double WindowWidth { get => _windowWidth; set => Set(ref _windowWidth, value).DoOnSuccess(state => RaisePropertyChanged(nameof(WindowSize))); }
        public CornerRadius CornerRadius { get => _cornerRadius; set => Set(ref _cornerRadius, value); }

        public string WindowSize => $"{WindowHeight:####} x {WindowWidth:####}";

        public ICommand SwitchThemeCommand { get; }
        public ICommand OpenSizePanelCommand { get; }
        public ICommand CloseSizePanelCommand { get; }

        private void SwitchTheme()
        {
            Theme = _isInDarkMode ? _light : _dark;
            _isInDarkMode = !_isInDarkMode;
        }

        private void OpenSizePanel()
        {
            SizePanel = new SizePanel()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                DataContext = this
            };
            SizePanel.Show();
            IsSizePanelOpen = true;
        }

        private void CloseSizePanel()
        {
            SizePanel.Close();
            IsSizePanelOpen = false;
        }
    }
}