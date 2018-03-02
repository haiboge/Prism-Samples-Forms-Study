using Prism.Ioc;
using Prism.Modularity;
using UsingModules.SampleModule.Views;
using UsingModules.SampleModule.ViewModels;
using Unity;

namespace UsingModules.SampleModule
{
    public class SampleModule : IModule
    {
        private readonly IUnityContainer _unityContainer;

        public SampleModule(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void Initialize()
        {
            _unityContainer.RegisterType<SamplePage>();
        }

        public void OnInitialized()
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SamplePage, SamplePageViewModel>();
        }
    }
}
