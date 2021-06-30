using System;
using System.Linq;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using CheeseBind;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using MvvmCross.WeakSubscription;
using Tools.Interfaces;
using Tools.ViewModels;

namespace FirstBrick.Droid.Views.Base
{
    public abstract class BaseActivity<T> : MvxActivity<T> where T : MvxViewModel
    {
        private IDisposable propertyChangedToken;

        protected bool UsesCheeseknife { get; private set; }

        protected abstract int LayoutId { get; }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            var modalFragment = this.SupportFragmentManager.Fragments?.FirstOrDefault(f => f is IModalFragment) as MvxFragment;
            if (modalFragment != null && modalFragment.ViewModel is BaseViewModel)
            {
                (modalFragment.ViewModel as BaseViewModel).CloseViewModelCommand?.Execute();

            }
            else
            {
                base.OnBackPressed();
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            this.SetContentView(this.LayoutId);
        }

        protected void InjectCheese()
        {
            if (!this.UsesCheeseknife)
            {
                Cheeseknife.Bind(this);
                this.UsesCheeseknife = true;
            }
        }

        protected void SubscribeToPropertyChanged()
        {
            this.propertyChangedToken = this.ViewModel.WeakSubscribe(this.OnViewModelPropertyChanged);
        }

        protected virtual void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            this.propertyChangedToken?.Dispose();

            if (this.UsesCheeseknife)
            {
                Cheeseknife.Reset(this);
            }
        }
    }
}
