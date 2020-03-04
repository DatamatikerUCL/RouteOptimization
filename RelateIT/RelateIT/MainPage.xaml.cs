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

        double width = 0;
        double height = 0;

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

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(5)));
        }


        private async void RouteOverviewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RouteOverview());
        }


    }
}
