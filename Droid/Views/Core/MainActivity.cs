using System;
using Android.App;
using FirstBrick.Droid.Views.Base;
using FirstBrick.ViewModels.ViewModels.Core;
using EU.Axeptio.Sdk;


namespace FirstBrick.Droid.Views.Core
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        protected override int LayoutId => Resource.Layout.core_activity_main;

        public MainActivity()
        {
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            //AxeptioKt.GetAxeptio(this).Initialize(null,null,null);
        }
    }
}
