using Prism;
using Prism.Ioc;
using MCS.PFS.ViewModels;
using MCS.PFS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Modularity;
using System;
using UsingModules.SampleModule;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MCS.PFS
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
            //await NavigationService.NavigateAsync("MainTabbedPage/NavigationPage/ShowsListPage/TabA");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();

            containerRegistry.RegisterForNavigation<UsingCompositeCommandPage>();
            containerRegistry.RegisterForNavigation<TabA, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabB, TabViewModel>();
            containerRegistry.RegisterInstance<IApplicationCommands>(new ApplicationCommands());

            containerRegistry.RegisterForNavigation<UsingDependencyServicePage>();
            containerRegistry.RegisterForNavigation<UsingPageDialogServicePage>();
            containerRegistry.RegisterForNavigation<UsingModulesPage>();
            containerRegistry.RegisterForNavigation<MainTabbedPage>();
            containerRegistry.RegisterForNavigation<UpcomingShowsPage>();
            containerRegistry.RegisterForNavigation<ShowsListPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type sampleModuleType = typeof(SampleModule);
            moduleCatalog.AddModule(new ModuleInfo(sampleModuleType, sampleModuleType.Name)
            {
                InitializationMode = InitializationMode.OnDemand
            });
        }
    }
}
