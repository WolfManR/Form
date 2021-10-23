using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Form.Models;
using Thundire.MVVM.WPF.Commands.Relay;
using Thundire.MVVM.WPF.Observable.Base;

namespace Form.ViewModels.Tools
{
    public class IconPaintVM : NotifyBase
    {
        private string _iconGeometry;
        private string _iconName;

        public IconPaintVM()
        {
            Icons = new();
            _iconGeometry = string.Empty;

            AddIconCommand = new RelayCommand(AddIconToList, () => !new[] { _iconGeometry, _iconName }.IsNotFilled());
            ClearFormCommand = new RelayCommand(ClearForm, () => !_iconGeometry.IsNotFilled() || !_iconName.IsNotFilled());
            ClearIconsListCommand = new RelayCommand(ClearIconsList, () => Icons.Count > 0);
        }

        public string IconGeometry { get => _iconGeometry; set => Set(ref _iconGeometry, value); }
        public string IconName { get => _iconName; set => Set(ref _iconName, value); }
        public ObservableCollection<IconData> Icons { get; }

        public ICommand AddIconCommand { get; }
        public ICommand ClearIconsListCommand { get; }
        public ICommand ClearFormCommand { get; }

        private void AddIconToList()
        {
            if(Icons.Any(i => i.Name == IconName)) return;

            Icons.Add(new IconData(IconGeometry, IconName));
        }

        private void ClearIconsList() => Icons.Clear();

        private void ClearForm() => IconGeometry = IconName = string.Empty;
    }
}