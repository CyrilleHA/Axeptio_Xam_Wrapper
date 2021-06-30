using System;
using Android.App;
using Android.Content.PM;
using EU.Axeptio.Sdk;
using FirstBrick.Droid.Views.Base;
using FirstBrick.ViewModels.ViewModels.Onboarding;

namespace FirstBrick.Droid.Views.Onboarding
{
    [Activity(NoHistory = true,
      MainLauncher = true,
      ScreenOrientation = ScreenOrientation.Portrait,
      Theme = "@style/MyTheme.Splashscreen")]
    public class SplashscreenActivity : BaseActivity<SplashscreenViewModel>
    {
        protected override int LayoutId => Resource.Layout.onboarding_activity_splashscreen;

        public SplashscreenActivity()
        {
        }

        protected override void OnStart()
        {
            base.OnStart();

            //Axeptio.Instance(this);
        }
    }
}
