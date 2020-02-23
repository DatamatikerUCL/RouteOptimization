using Android.OS;
using Microsoft.Web.XmlTransform;
using Plugin.Geolocator;
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

            InitializeComponent();

            CenterOnUserLocation();

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

        public async void CenterOnUserLocation()
        {

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(5)));
        }


    }
}
