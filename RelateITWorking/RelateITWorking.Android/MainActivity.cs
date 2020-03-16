
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Android.Gms.Maps;
using Plugin.Permissions;
using Position = Xamarin.Forms.Maps.Position;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace RelateIT.Droid
{
    [Activity(Label = "RelateIT", Icon = "@mipmap/icon", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IOnMapReadyCallback
    {
        Location location;

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
            LoadApplication(new App());

            location = new Location(); 


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

        public Task<Location>GetLastKnownLocation()
        {
            var location = Geolocation.GetLastKnownLocationAsync();
            

            return location;
        }

        
       protected override void OnStart()
       {
           base.OnStart();

       }
        
        /*
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

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
        }*/
       
       
        protected override void OnSaveInstanceState(Bundle savedInstanceState)
        {
            base.OnSaveInstanceState(savedInstanceState);
     

        }
    }
}