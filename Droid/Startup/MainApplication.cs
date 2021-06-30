using System;
using Android.App;
using Android.Runtime;
using FirstBrick.ViewModels.Startup;
using MvvmCross.Platforms.Android.Views;

namespace FirstBrick.Droid.Startup
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }
    }
}
