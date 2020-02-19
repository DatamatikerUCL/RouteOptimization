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
            Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map();
            Content = map;

            InitializeMap();

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

        public void InitializeMap()
        {
            map = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(GetDeviceLocation().Result.Latitude, GetDeviceLocation().Result.Longitude), Distance.FromKilometers(5)))
            {
                IsShowingUser = true,
            };

            map2 = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(GetDeviceLocation().Result.Latitude, GetDeviceLocation().Result.Longitude), Distance.FromKilometers(5)))
            {
                IsShowingUser = true,
            };
        }

        public async Task<Location> GetDeviceLocation()
        {

            var location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }
    }
}
