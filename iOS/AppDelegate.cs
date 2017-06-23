using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace VisibleViewController.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);

            var topController = GetVisibleViewController();

            Debug.WriteLine("topController : " + topController.ToString());
        }

        UIViewController GetVisibleViewController(UIViewController controller = null)
        {
            controller = controller ?? UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (controller.ChildViewControllers.Count() == 1)
            {
                // -- Container
                controller = controller.ChildViewControllers[0];
            }

            if (controller is UINavigationController)
            {
                return GetVisibleViewController(((UINavigationController)controller).TopViewController);
            }

            if (controller is UITabBarController)
            {
                return GetVisibleViewController(((UITabBarController)controller).SelectedViewController);
            }

            if (controller is TabletMasterDetailRenderer) // -- UISplitViewController
            {
                return GetVisibleViewController(((UISplitViewController)controller).ViewControllers[1]);
            }

            if (controller is PhoneMasterDetailRenderer)
            {
                return GetVisibleViewController(((UIViewController)controller).ChildViewControllers[1]);
            }

            if (controller is UIViewController)
            {
                if (controller.ChildViewControllers.Count() == 1)
                {
                    // -- Container
                    return (UIViewController)controller.ChildViewControllers[0];
                }
                return (UIViewController)controller;
            }

            return controller;
        }
    }
}
