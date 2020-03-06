using Android;
using AngleSharp.Dom;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;


namespace RelateIT
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        double width = 0;
        double height = 0;

        public MainPage()
        {
            InitializeComponent();
            // CenterOnUserLocation();
           // GetDeviceLocationAsync();

            if (Device.Idiom == TargetIdiom.Phone)
            {
                PhoneView.IsVisible = true;
                TabletView.IsVisible = false;
            }
            else
            {
                PhoneView.IsVisible = false;
                TabletView.IsVisible = true;
            }

            Task.Factory.StartNew(CheckLocationPermission);

        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    PhoneView.RowDefinitions.Clear();
                    PhoneView.ColumnDefinitions.Clear();
                    PhoneView.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) });
                    PhoneView.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    PhoneView.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }
                else
                {
                    PhoneView.RowDefinitions.Clear();
                    PhoneView.ColumnDefinitions.Clear();
                    PhoneView.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
                    PhoneView.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Star) });
                    PhoneView.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        
                }
            }
        }

        public async void CenterOnUserLocation()
        /*public async void CenterOnUserLocation()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                var position = await GetLocationAsync();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(5)));
            }
            else
            {
                var requestPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

        }*/

        public async void CheckLocationPermission()
        {
            PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //hjkl
                    }
                });

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = result.FirstOrDefault().Value;
                });

                // Notify user permission was denied
                await DisplayAlert("Access Denied", "Access was denied by you", "OK");
            }

            if (status == PermissionStatus.Granted)
            {
                //turn on location
               DependencyService.Get<ILocation>().TurnOnGps();
            }
            
        }

        //public async Task<Plugin.Permissions.Abstractions.PermissionStatus> CheckAndRequestPermissionAsync<TPermission>(TPermission permission)
        //     where TPermission : BasePermission
        //{
        //    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //    if (status != PermissionStatus.Granted)
        //    {
        //        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        //    }

        //    // Additionally could prompt the user to turn on in settings

        //    return status;
        //}


        private async void RouteOverviewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RouteOverview());
        }


    }
}
