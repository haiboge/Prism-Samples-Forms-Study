using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCS.PFS.ViewModels
{
	public class TabViewModel : BindableBase
	{
        public TabViewModel(IApplicationCommands applicationCommands)
        {
            applicationCommands.SaveCommand.RegisterCommand(SaveCommand);
            applicationCommands.ResetCommand.RegisterCommand(ResetCommand);
        }

        public DelegateCommand SaveCommand => new DelegateCommand(Save);
        public DelegateCommand ResetCommand => new DelegateCommand(Reset);

        private void Reset()
        {
            LastSaved = "Reset - no value";
        }

        private void Save()
        {
            LastSaved = DateTime.Now.ToString();
        }

        private string _lastSaved;
        public string LastSaved
        {
            get { return _lastSaved; }
            set { SetProperty(ref _lastSaved, value); }
        }
    }
}
