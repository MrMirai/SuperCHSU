using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace SuperCHSU.MainModule.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        public string Text { get; set; }
        IRegionManager _region;
        public MainWindowViewModel(IRegionManager region)
        {
            _region = region;
        }
   
        private DelegateCommand<string> _command;
        public DelegateCommand<string> Command => _command ?? (_command = new DelegateCommand<string>(ExecuteCommand));
        private void ExecuteCommand(string uri)
        {
            _region.RequestNavigate("ContentRegion", uri);
        }
    }
}
