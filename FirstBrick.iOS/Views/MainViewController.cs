// This file has been autogenerated from a class added in the UI designer.

using System;
using FirstBrick.iOS.Views.Base;
using FirstBrick.ViewModels.ViewModels.Core;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using NativeLibrary;
using UIKit;

namespace FirstBrick.iOS.Views
{
    [MvxFromStoryboard("Core")]
	public partial class MainViewController : BaseViewController<MainViewModel>
	{
        public MainViewController(IntPtr handle) : base(handle)
        {
         
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            try
            {
               //var i = Axeptio.Token;
               // Axeptio.ClearUserConsents();
           //     Axeptio.InitializeWithClientId(null, null, null);
            }
            catch(Exception e)
            {

            }
        }
    }
}