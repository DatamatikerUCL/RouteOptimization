﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Gms.Maps;
using RelateIT.Droid;
using Android.Gms.Maps.Model;
using Xamarin.Forms.Maps;
using RelateIT;

namespace RelateIT.Droid
{
    [Activity(Label = "RelateIT", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IOnMapReadyCallback
    {

        //MapView mapView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // if instance state is not null, the restore saved state, and values otherwise start over
            if(savedInstanceState != null)
            {

            }
        }

        public void OnMapReady(GoogleMap map)
        {
            // Do something with the map, i.e. add markers, move to a specific location, etc.
            map.MapType = GoogleMap.MapTypeNormal;
            map.UiSettings.ZoomControlsEnabled = true;
            map.UiSettings.CompassEnabled = true;

        }

        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override void OnStart()
        {
            base.OnStart();

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {

                    RequestPermissions(LocationPermissions, RequestLocationId);
                    //Position position = new Position(LocationHelper.OnGetDeviceLastLocation().Result.Latitude, LocationHelper.OnGetDeviceLastLocation().Result.Longitude);
                    //MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
                    //Map map = new Map(mapSpan);
                }
                else
                {
                    //Position position = new Position(LocationHelper.OnGetCurrentLocation().Result.Latitude, LocationHelper.OnGetCurrentLocation().Result.Longitude);
                    //MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
                    //Map map = new Map(mapSpan);

                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Adgang allerede givet");
                    alert.SetMessage("Adgang er givet til lokationen");
                    alert.Show();
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                {
                    // Permissions granted - display a message.
                    AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Adgang givet");
                    alert.SetMessage("Adgang er givet til lokation");
                    alert.Show();
                }

                else
                {
                    // Permissions denied - display a message.
                    AlertDialog.Builder dialog2 = new AlertDialog.Builder(this);
                    AlertDialog alert2 = dialog2.Create();
                    alert2.SetTitle("Adgang ikke givet");
                    alert2.SetMessage("Adgang blokeret, da tilladelse ikke blev givet");
                    alert2.Show();
                }

            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        // for saving state on orientation change so that it can be restored later
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        // for restoring the state that was saved ealier
        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

    }
}