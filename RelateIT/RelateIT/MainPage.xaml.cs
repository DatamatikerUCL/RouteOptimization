using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RelateIT
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            Position position = new Position(OnGetDeviceLocation().Result.Latitude, OnGetDeviceLocation().Result.Longitude);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan);


            OnInitializeMap();

            InitializeComponent();
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

        }

        public void OnInitializeMap()
        {
            map = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(OnGetDeviceLocation().Result.Latitude, OnGetDeviceLocation().Result.Longitude), Distance.FromKilometers(5)))
            {
                IsShowingUser = true,
            };

            map2 = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(OnGetDeviceLocation().Result.Latitude, OnGetDeviceLocation().Result.Longitude), Distance.FromKilometers(5)))
            {
                IsShowingUser = true,
            };
        }

        public async Task<Location> OnGetDeviceLocation()
        {

            var location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }
    }
}
