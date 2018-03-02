using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MCS.PFS.ViewModels
{
	public class UsingPageDialogServicePageViewModel : BindableBase
	{
        private readonly IPageDialogService _pageDialogService;

        public DelegateCommand DisplayAlertCommand { get; set; }

        public DelegateCommand DisplayActionSheetCommand { get; set; }

        public DelegateCommand DisplayActionSheetUsingActionSheetButtonsCommand { get; set; }

        public UsingPageDialogServicePageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;

            DisplayAlertCommand = new DelegateCommand(DisplayAlertAsync);

            DisplayActionSheetCommand = new DelegateCommand(DisplayActionSheetAsync);

            DisplayActionSheetUsingActionSheetButtonsCommand = new DelegateCommand(DisplayActionSheetUsingActionSheetButtons);

        }

        private void DisplayActionSheetUsingActionSheetButtons()
        {
            IActionSheetButton option1Action = ActionSheetButton.CreateButton("Option 1", new DelegateCommand(() => Debug.WriteLine("Option 1")));
            IActionSheetButton option2Action = ActionSheetButton.CreateButton("Option 2", new DelegateCommand(() => Debug.WriteLine("Option 2")));
            IActionSheetButton option3Action = ActionSheetButton.CreateButton("Option 3", new DelegateCommand(() => Debug.WriteLine("Option 3")));
            IActionSheetButton option4Action = ActionSheetButton.CreateButton("Option 4", new DelegateCommand(() => Debug.WriteLine("Option 4")));
            IActionSheetButton option5Action = ActionSheetButton.CreateButton("Option 5", new DelegateCommand(() => Debug.WriteLine("Option 5")));
            IActionSheetButton option6Action = ActionSheetButton.CreateButton("Option 6", new DelegateCommand(() => Debug.WriteLine("Option 6")));

            _pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", option1Action, option2Action, option3Action, option4Action, option5Action, option6Action);
        }

        private async void DisplayActionSheetAsync()
        {
            var result = await _pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destroy", "Option1", "Option2", "Option3");
            Debug.WriteLine(result);
        }

        private async void DisplayAlertAsync()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "This is an alert from UsingPageDialogServicePage", "Accept", "Cancel");
            Debug.WriteLine(result);
        }
    }
}
