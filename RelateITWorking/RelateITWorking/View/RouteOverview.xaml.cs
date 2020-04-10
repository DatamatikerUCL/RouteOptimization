using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Net.Wifi.Aware;
using RelateIT.Interfaces;
using RelateITWorking;
using RouteOptimization.RoutePlanner.Datastructures;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace RelateIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteOverview : ContentPage
    {

        public RouteOverview(IDataAccessable dataAccesser)
        {
            InitializeComponent();
            BindingContext = dataAccesser.GetRoutes().ToList();

            routeListview.ItemTapped += async (sender, e) =>
            {
                var item = (Route)e.Item;
                if (item == null)
                {
                    await this.DisplayAlert("Tapped", "No item was tapped", "OK", null);
                }
                else
                {
                    await this.Navigation.PushAsync(new MainPage());
                }


            };

        }




    }
}