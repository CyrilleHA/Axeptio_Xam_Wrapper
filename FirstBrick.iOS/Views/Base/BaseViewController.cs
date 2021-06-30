using System;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.WeakSubscription;
using Tools.ViewModels;
using UIKit;

namespace FirstBrick.iOS.Views.Base
{
    public abstract class BaseViewController<T> : MvxViewController<T> where T : BaseViewModel
    {
        private MvxNotifyPropertyChangedEventSubscription propertyChangedToken;

        public BaseViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

            this.propertyChangedToken?.Dispose();
            this.propertyChangedToken = null;
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            if (parent == null)
            {
                this.propertyChangedToken?.Dispose();
                this.propertyChangedToken = null;
            }

            base.DidMoveToParentViewController(parent);
        }

        protected void SubscribeToPropertyChanged()
        {
            this.propertyChangedToken = this.ViewModel.WeakSubscribe(this.OnViewModelPropertyChanged);
        }

        protected virtual void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
    }
}
