using System;
using FirstBrick.ViewModels.ViewModels.Core;
using FirstBrick.ViewModels.ViewModels.Onboarding;
using MvvmCross.ViewModels;

namespace FirstBrick.ViewModels.Startup
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.RegisterAppStart<SplashscreenViewModel>();
        }
    }
}
