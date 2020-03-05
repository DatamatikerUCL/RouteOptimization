using HPlusSports.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using Plugin.Geolocator;

namespace HPlusSports
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var location = GetLocationAsync();

            if (location == null)
            {
                DisplayAlert("Location is not turned on", "sad", "OK");
            }
            else
            {
               DisplayAlert("Location", $"your current location is {location.Result.Latitude} ,  {location.Result.Longitude}", "OK");

            }
           


        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Services.Product product = e.CurrentSelection.First() as Services.Product;
            Navigation.PushAsync(new ProductDetails(product));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            INetworkManager manager = DependencyService.Get<INetworkManager>();
            if (manager != null && manager.IsNetWorkConnected())
            {
                    var products = await ProductService.GetProductsAsync();
                    BindingContext = products;               
            }
            else
            {
                await DisplayAlert("Not connected", "You're not connected to the network", "OK");
            }
        }

        private void fvt_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Favorits(ProductService.WishList));
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

        public async Task<Plugin.Geolocator.Abstractions.Position> GetLocationAsync()
        {
            var status = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
            if (status != PermissionStatus.Granted)
            {
                // Notify user permission was denied
                return null;
            }

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1000.0;
            if (!CrossGeolocator.IsSupported || !locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
            {
                return null;
            }

            var postion = await locator.GetPositionAsync(TimeSpan.FromSeconds(3), null, true);
            var p1 = postion;
            return postion;
        }
    }
}
