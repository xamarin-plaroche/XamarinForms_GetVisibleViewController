# XamarinForms_GetVisibleViewController
GetVisibleViewController() function for iOS part of an Xamarin Forms Application

This function allows you to find the current UIController displayed.

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
