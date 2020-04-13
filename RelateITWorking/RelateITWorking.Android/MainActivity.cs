
using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Android.Gms.Maps;
using Plugin.Permissions;
using Position = Xamarin.Forms.Maps.Position;
using RelateIT.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Gms.Maps.Model;
using Newtonsoft.Json;
using RelateITWorking.Helpers;
using RelateITWorking.Models;
using RelateITWorking.ViewModel;
using Windows.Web.Http;

/*using TK.CustomMap.Api.Google;
using TK.CustomMap.Droid;*/


namespace RelateIT.Droid
{
    [Activity(Label = "RelateIT", Icon = "@mipmap/icon", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IOnMapReadyCallback
    {
        Xamarin.Essentials.Location location;
        private MainPage mainpage;
        private string directionsAPIURL = "";
        public ConvertKommaToDot _convertKomma;
        private RootObject rootObject;
        private RouteViewModel _routeViewModel;

        //MapView mapView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            /*
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;*/
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //GmsDirection.Init("AIzaSyAr5VXtkDkCSpG3BvQVynoiFL-rvmZtxoM");
            //TKGoogleMaps.Init(this, savedInstanceState);
            location = new Xamarin.Essentials.Location();
            _convertKomma = new ConvertKommaToDot();
            rootObject = new RootObject();
            mainpage = new MainPage();
            _routeViewModel = new RouteViewModel();


            LoadApplication(new App());


            location = GetLastKnownLocation().Result;

            if (savedInstanceState != null)
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


        /* readonly string[] LocationPermissions =
         {
             Manifest.Permission.AccessCoarseLocation,
             Manifest.Permission.AccessFineLocation
         };*/

        public Task<Xamarin.Essentials.Location> GetLastKnownLocation()
        {
            var location = Xamarin.Essentials.Geolocation.GetLastKnownLocationAsync();


            return location;
        }


        protected override void OnStart()
        {
            base.OnStart();

        }



        protected override void OnSaveInstanceState(Bundle savedInstanceState)
        {
            base.OnSaveInstanceState(savedInstanceState);


        }
    }
}