using MvvmCross.Navigation;
using Tools.Interfaces;

namespace Tools.ViewModels
{
    public abstract class BaseEntityViewModel<T> : BaseViewModel, IModelContainer<T>
    {
        private T model;

        public virtual T Model
        {
            get => this.model;
            set
            {
                this.model = value;
                this.OnModelSet();
            }
        }

        protected BaseEntityViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        protected BaseEntityViewModel() : base()
        {
        }

        protected virtual void OnModelSet()
        {
        }
    }
}
