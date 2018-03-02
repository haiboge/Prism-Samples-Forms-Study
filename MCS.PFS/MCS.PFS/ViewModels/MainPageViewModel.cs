using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MCS.PFS.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        private INavigationService _navigationService { get; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            _navigationService = navigationService;
            Title = "Main Page";
        }

        public DelegateCommand NavigateCommand => 
            new DelegateCommand(NavigateToUsingCompositeCommandPage);

        private void NavigateToUsingCompositeCommandPage()
        {
            _navigationService.NavigateAsync("UsingCompositeCommandPage");
        }

        public DelegateCommand NavigateToUsingDependencyServicePageCommand =>
            new DelegateCommand(NavigateToUsingDependencyServicePage);

        private void NavigateToUsingDependencyServicePage()
        {
            _navigationService.NavigateAsync("UsingDependencyServicePage");
        }

        public DelegateCommand UsingPageDialogServicePageCommand => 
            new DelegateCommand(NavigateToUsingPageDialogServicePage);

        private void NavigateToUsingPageDialogServicePage()
        {
            _navigationService.NavigateAsync("UsingPageDialogServicePage");
        }

        public DelegateCommand NavigateToSampleModulePageCommand =>
            new DelegateCommand(NavigateToSampleModulePage);

        private void NavigateToSampleModulePage()
        {
            _navigationService.NavigateAsync("UsingModulesPage");
        }

        public ICommand _navigateToUpcomingShowsPage;
        public ICommand NavigateToUpcomingShowsPageCommand => 
            _navigateToUpcomingShowsPage ?? (_navigateToUpcomingShowsPage = new DelegateCommand(OnNavigateToUpcomingShowsPage));

        private void OnNavigateToUpcomingShowsPage()
        {
            _navigationService.NavigateAsync("MainTabbedPage");
        }
    }
}
