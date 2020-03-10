using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

        protected override async void OnAppearing()
        {
            var location = GetLocationAsync();

            if (location == null)
            {
                await DisplayAlert("Location is not turned on", "sad", "OK");
            }
            else
            {
                await DisplayAlert("Location", $"your current location is {location.Result.Latitude} ,  {location.Result.Longitude}", "OK");
            }
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
                await GetLocationAsync();
                return null;
            }

            DependencyService.Get<ITurnOnGPS>().turnOnGPS();

            var location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }
    }
}