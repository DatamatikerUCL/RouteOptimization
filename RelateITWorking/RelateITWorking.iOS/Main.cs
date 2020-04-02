using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using UIKit;

namespace RelateIT.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

            PromptLocationPermission();

        }

        public static async void PromptLocationPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                {

                    var window = UIApplication.SharedApplication.KeyWindow;
                    var vc = window.RootViewController;
                    while (vc.PresentedViewController != null)
                    {
                        vc = vc.PresentedViewController;
                    }

                    var alert = UIAlertController.Create("Need Location", "We need your location", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Destructive, (action) =>
                    {
                        // otherTitle();
                    }));
                    alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
                    vc.PresentViewController(alert, true, null);
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                status = results[Permission.Location];
            }
        }

        public void OnSaveInstance(NSBundle savedInstance)
        {

        }
    }
}
