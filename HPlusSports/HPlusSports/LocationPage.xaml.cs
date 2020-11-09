using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using static Xamarin.Essentials.Permissions;

namespace HPlusSports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
           where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }
            return status;


        }

        public async Task<Location> GetLocationAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
            if (status != PermissionStatus.Granted)
            {                
                return null;
            }
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, new TimeSpan(0, 0, 3));
            var location = await Geolocation.GetLocationAsync(request);
            return location;
        }

        private async void Location_Clicked(object sender, EventArgs e)
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
            if (status != PermissionStatus.Granted)
            {
                await DisplayAlert("Faild", "Promision wasnt granted", "OK");
                await Navigation.PopAsync();
            }
            DependencyService.Get<ITurnOnGPS>().turnOnGPS();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, new TimeSpan(0, 0, 3));
                var location = await Geolocation.GetLocationAsync(request);
                //var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Longitude:" + location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }
    }
}