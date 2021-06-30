using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Tools.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private bool isBusy;
        private object instancelock = new object();
        private int taskCount;
        private MvxAsyncCommand closeViewModelCommand;

        protected IMvxNavigationService NavigationService { get; private set; }

        public virtual bool IsBusy
        {
            get => this.isBusy;
            set
            {
                this.SetProperty(ref this.isBusy, value);
                this.RaisePropertyChanged(nameof(this.IsNotBusy));
                this.OnIsBusyChanged();
            }
        }

        public virtual TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public bool IsNotBusy => !this.IsBusy;

        public virtual MvxAsyncCommand CloseViewModelCommand => this.closeViewModelCommand ??
                                                      (this.closeViewModelCommand = new MvxAsyncCommand(this.CloseViewModelCommandExecute));

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (this.CloseCompletionSource != null && !this.CloseCompletionSource.Task.IsCompleted && !this.CloseCompletionSource.Task.IsFaulted)
                this.CloseCompletionSource?.TrySetCanceled();
            base.ViewDestroy(viewFinishing);
        }

        public virtual BusyContext StartBusyContext()
        {
            this.UpdateBusyState(1);

            return new BusyContext(() => this.UpdateBusyState(-1));
        }

        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        protected BaseViewModel()
        {
            this.NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        protected virtual Task CloseViewModelCommandExecute()
        {
            return this.NavigationService.Close(this);
        }

        protected virtual void OnIsBusyChanged()
        {
        }

        private void UpdateBusyState(int count)
        {
            lock (this.instancelock)
            {
                this.taskCount += count;
                this.IsBusy = this.taskCount > 0;
            }
        }
    }
}
