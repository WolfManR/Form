using System;
using System.Windows;
using System.Windows.Input;
using Thundire.MVVM.WPF.Commands.Relay;
using Thundire.MVVM.WPF.Observable.Base;

namespace Form.ViewModels.Tools
{
    public class GuidGeneratorVM : NotifyBase
    {
        private string _generatedGuid;
        private bool _isAutoCopyToClipboard;
        private bool _isGenerateGuidInUpperCase;

        public GuidGeneratorVM()
        {
            CopyGeneratedGuidToClipboardCommand = new RelayCommand(CopyGeneratedGuidToClipboard, () => !GeneratedGuid.IsNotFilled());
            GenerateCommand = new RelayCommand(Generate);
        }

        public string GeneratedGuid { get => _generatedGuid; set => Set(ref _generatedGuid, value); }
        public bool IsAutoCopyToClipboard { get => _isAutoCopyToClipboard; set => Set(ref _isAutoCopyToClipboard, value); }
        public bool IsGenerateGuidInUpperCase { get => _isGenerateGuidInUpperCase; set => Set(ref _isGenerateGuidInUpperCase, value); }

        public ICommand CopyGeneratedGuidToClipboardCommand { get; }
        public ICommand GenerateCommand { get; }

        private void CopyGeneratedGuidToClipboard()
        {
            Clipboard.SetText(GeneratedGuid);
        }

        private void Generate()
        {
            var guid = Guid.NewGuid().ToString();
            if(IsGenerateGuidInUpperCase) guid = guid.ToUpper();
            GeneratedGuid = guid;
            if(_isAutoCopyToClipboard) CopyGeneratedGuidToClipboard();
        }
    }
}