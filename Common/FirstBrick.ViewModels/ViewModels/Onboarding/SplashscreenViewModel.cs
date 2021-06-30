using System;
using System.Threading.Tasks;
using FirstBrick.ViewModels.ViewModels.Core;
using Tools.ViewModels;

namespace FirstBrick.ViewModels.ViewModels.Onboarding
{
    public class SplashscreenViewModel : BaseViewModel
    {
        public SplashscreenViewModel()
        {
        }

        public async override Task Initialize()
        {
            await base.Initialize();

            _ = this.LoadContent();
        }

        private async Task LoadContent()
        {
            await Task.Delay(1000);
            await this.OnLoadFinished();
        }

        private Task OnLoadFinished()
        {
            return this.NavigationService.Navigate<MainViewModel>();
        }
    }
}
