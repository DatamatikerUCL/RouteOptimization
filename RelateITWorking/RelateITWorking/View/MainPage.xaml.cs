
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml;
using Newtonsoft.Json;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Protocol;
using Plugin.Geolocator;
using Xamarin.Forms;
using RelateIT.Interfaces;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RelateIT.Models;
using RelateIT.Repositories;
using RelateITWorking;
using RelateITWorking.ViewModel;
using Permission = Plugin.Permissions.Abstractions.Permission;

using MapSpan = Xamarin.Forms.Maps.MapSpan;
using Xamarin.Forms.Maps;
using Pin = Xamarin.Forms.Maps.Pin;
using PinType = Xamarin.Forms.Maps.PinType;
using Position = Xamarin.Forms.Maps.Position;
using RelateITWorking.Helpers;
using RelateITWorking.Models;
using Route = RelateIT.Models.Route;
using Distance = Xamarin.Forms.Maps.Distance;
using Polyline = Xamarin.Forms.Maps.Polyline;

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
        private string directionsAPIURL = "";
        public ConvertKommaToDot _convertKomma;
        private RootObject rootObject;


        public MainPage()
        {
            _dataAcesser = new MockRouteData();
            _routeRepo = RouteRepo.GetInstance(_dataAcesser);
            _routeOverviewViewModel = new RouteOverviewViewModel();
            _convertKomma = new ConvertKommaToDot();
            rootObject = new RootObject();
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
            //GetJSON();
            DrawPath();

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
                    PhoneView.ColumnDefinitions.Add(new ColumnDefinition
                    { Width = new GridLength(1, GridUnitType.Star) });
                    PhoneView.ColumnDefinitions.Add(new ColumnDefinition
                    { Width = new GridLength(1, GridUnitType.Star) });
                }
                else
                {
                    PhoneView.RowDefinitions.Clear();
                    PhoneView.ColumnDefinitions.Clear();
                    PhoneView.ColumnDefinitions.Add(
                        new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
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
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longtitude),
                Distance.FromKilometers(1)));
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
                Position = new Position(_routeViewModel.GetLocationLatitude(routeId),
                    _routeViewModel.GetLocationLongitude(routeId))
            };
            map.Pins.Add(pin);
        }

        /*  private void DrawPath()
          {
              GetJSON();

              List<Location> lines = DecodePolylinePoints(rootObject.routes[0].overview_polyline.points);
              var polylineOptions = new PolylineOptions()
                  .InvokeColor(Android.Graphics.Color.Blue)
                  .InvokeWidth(4);

              foreach (Location line in lines)
              {
                  polylineOptions.Add(line);
              }

              Map.AddPolyline(polylineOptions);

          }*/

        public string MakeURL()
        {
            List<Location> locations = new List<Location>();
            foreach (Location location in _routeViewModel.GetRoute().Locations)
            {
                locations.Add(location);
            }

            List<Position> positions = locations.ConvertAll(l => new Position(l.Latitude, l.Longtitude));


            directionsAPIURL =
                "https://maps.googleapis.com/maps/api/directions/json?origin=" + _convertKomma.ConvertKommaToDots(positions[0].Latitude) + ","
                + _convertKomma.ConvertKommaToDots(positions[0].Longitude) + "&destination=" + _convertKomma.ConvertKommaToDots(positions.Last().Latitude) + ","
                + _convertKomma.ConvertKommaToDots(positions.Last().Longitude) + "&key=AIzaSyAr5VXtkDkCSpG3BvQVynoiFL-rvmZtxoM";

            return directionsAPIURL;
        }

        public async Task<string> GetJSONAsync(string url)
        {
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string response = await client.GetStringAsync(url);
            return response;
        }
        /*
        public async void GetJSON()
        {
            
            
            var client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = await client.GetAsync(directionsAPIURL);

  
            string directionsJSON = await response.Content.ReadAsStringAsync();

            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string response = await client.GetStringAsync(directionsAPIURL);

            if (response != "")
            {
                rootObject = JsonConvert.DeserializeObject<RootObject>(response);

            }


        }
        */

        public async void DrawPath()
        {

            string jsonElement = await GetJSONAsync(MakeURL());

            rootObject = JsonConvert.DeserializeObject<RootObject>(jsonElement);

            List<Position> positions = new List<Position>();


            foreach (var item in rootObject.routes[0].legs[0].steps)
            {

                Position startPosition = new Position(item.start_location.lat, item.start_location.lng);
                Position endPosition = new Position(item.end_location.lat, item.end_location.lng);
                positions.Add(startPosition);
                positions.Add(endPosition);
            }

            Polyline polyline = new Polyline();
            polyline.StrokeColor = Color.Red;
            polyline.StrokeWidth = 12;
            for (int i = 0; i < positions.Count; i++)
            {
                polyline.Geopath.Add(positions[i]);
            }


            map.MapElements.Add(polyline);
        }
        /*

        private List<Location> DecodePolylinePoints(string encodedPoints)
        {
            if (encodedPoints == null || encodedPoints == "") return null;
            List<Location> poly = new List<Location>();
            char[] polylinechars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    Location p = new Location();
                    p.Latitude = Convert.ToDouble(currentLat) / 100000.0;
                    p.Longtitude = Convert.ToDouble(currentLng) / 100000.0;
                    poly.Add(p);
                }
            }
            catch (Exception ex)
            {
                // logo it
            }
            return poly;
        }
        */

    }
}
