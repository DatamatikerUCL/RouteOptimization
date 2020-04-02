
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using RelateIT.Interfaces;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RelateIT.Models;
using RelateIT.Repositories;
using RelateITWorking;
using RelateITWorking.ViewModel;
using Xamarin.Forms.GoogleMaps;
using Permission = Plugin.Permissions.Abstractions.Permission;
using Xamarin.Forms.Xaml;
using Distance = Xamarin.Forms.Maps.Distance;
using MapSpan = Xamarin.Forms.Maps.MapSpan;
using Pin = Xamarin.Forms.Maps.Pin;
using PinType = Xamarin.Forms.Maps.PinType;
using Position = Xamarin.Forms.Maps.Position;

namespace RelateIT
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        double width = 0;
        double height = 0;
        private readonly RouteViewModel _routeViewModel;
        private readonly RouteOverviewViewModel _routeOverviewViewModel;
        private readonly RouteRepo _routeRepo;
        private IDataAccessable _dataAcesser;
        internal static string _googleDirectionApiUrl = "https://maps.googleapis.com/maps/api/directions/json?origin=src_locn&destination=dest_lcn&key=AIzaSyAr5VXtkDkCSpG3BvQVynoiFL-rvmZtxoM";
        public MainPage()
        {
            _dataAcesser = new MockRouteData();
            _routeRepo = RouteRepo.GetInstance(_dataAcesser);
            _routeOverviewViewModel = new RouteOverviewViewModel();
            InitializeComponent();



            if (Device.Idiom == TargetIdiom.Phone)
            {
                PhoneView.IsVisible = true;
                TabletView.IsVisible = false;
                Task.Factory.StartNew(CheckLocationPermission);

            }
            else
            {
                PhoneView.IsVisible = false;
                TabletView.IsVisible = true;
                Task.Factory.StartNew(CheckLocationPermission);

            }


            for (int i = 0; i < _routeOverviewViewModel.GetRoutes().Count; i++)
            {
                // måske ændres
                _routeViewModel = new RouteViewModel(i);
                for (int k = 0; k < _routeViewModel.GetRoute().Locations.Count; k++)
                {
                    PlacePins(k);
                }
            }

            CenterOnRoute();
            // GetDeviceLocationAsync();
            //CenterOnUserLocation();

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
        {
            // var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            // if (status.Equals(PermissionStatus.Granted))
            // {
            var position = await GetPosition();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longtitude), Distance.FromKilometers(1)));
            //  }
            /* else
              {
                  var requestPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
              }*/

        }


        public async void CenterOnRoute()
        {
            var routePosition = new Position(55.4211854, 10.3507287);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(routePosition, Distance.FromKilometers(2)));
        }

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
                DependencyService.Get<ITurnOnLocation>().TurnOnGPS();
            }

        }


        private async Task<Models.Location> GetPosition()
        {
            Models.Location p = new Models.Location();
            if (CrossGeolocator.Current.IsGeolocationAvailable)
            {
                if (CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));


                    p = new Models.Location(position.Latitude, position.Longitude);

                }
                else
                {
                    await DisplayAlert("Message", "GPS not enabled", "OK");

                }
            }
            else
            {
                await DisplayAlert("Message", "GPS not available", "OK");
            }

            return p;
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
            // MockData
            RouteRepo tempRepo = RouteRepo.GetInstance();
            await Navigation.PushAsync(new RouteOverview(tempRepo));
        }

        //place pins for a location in a route
        private void PlacePins(int routeId)
        {

            Pin pin = new Pin
            {
                Label = _routeViewModel.GetRouteName(),
                Address = _routeViewModel.GetRouteAdress(routeId),
                Type = PinType.Place,
                Position = new Position(_routeViewModel.GetRouteLatitude(routeId), _routeViewModel.GetRouteLongitude(routeId))
            };
            map.Pins.Add(pin);
        }

        private void UpdateCameraPosition(Location position)
        {

        }


    }
}
