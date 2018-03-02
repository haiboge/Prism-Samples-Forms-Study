using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCS.PFS.ViewModels
{
	public class UsingCompositeCommandPageViewModel : BindableBase
	{
        private IApplicationCommands _applicationCommands;
        
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
        public UsingCompositeCommandPageViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
	}
}
