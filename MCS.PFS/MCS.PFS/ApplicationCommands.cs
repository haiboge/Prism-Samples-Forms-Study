using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.PFS
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
        CompositeCommand ResetCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        CompositeCommand _saveCommand = new CompositeCommand();

        public CompositeCommand SaveCommand => _saveCommand;

        CompositeCommand _resetCommand = new CompositeCommand();

        public CompositeCommand ResetCommand => _resetCommand;
    }
}
