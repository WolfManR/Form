using Form.ViewModels.Tools;
using Thundire.MVVM.WPF.Observable.Base;

namespace Form.ViewModels
{
    public class MainVM : NotifyBase
    {
        public MainVM()
        {
            SizePanelVM = new();
            IconPaintVM = new();
            GuidGeneratorVM = new();
        }

        public SizePanelVM SizePanelVM { get; }
        public IconPaintVM IconPaintVM { get; }
        public GuidGeneratorVM GuidGeneratorVM { get; }
    }
}