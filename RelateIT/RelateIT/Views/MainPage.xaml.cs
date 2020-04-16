using Newtonsoft.Json;
using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace RelateIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.374181, 10.403406), Distance.FromKilometers(1)));
        }
            
        public MainPage(int id)
        {
            InitializeComponent();
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.374181, 10.403406), Distance.FromKilometers(1)));
        }

        private async void Btn_RouteOverView_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Not implemetet", "asdad", "OK");
        }

        private async void Btn_CreateNewRoute_Clicked(object sender, EventArgs e)
        {            
            string json = await Services.MapFunctionHelper.GetDirectionJsonAsync(55.374181, 10.403406, 55.403772, 10.379840);
            DrawTripOnMap(json);
        }
        public void DrawTripOnMap(string json)
        {
            var directionData = JsonConvert.DeserializeObject<Services.RootObject>(json);


            var route = Services.GooglePoints.Decode(directionData.routes[0].overview_polyline.points);     
           
            Polyline polyline = new Polyline();

            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWidth = 12;

            foreach (var item in route)
            {
                polyline.Geopath.Add(item);
            }           

            Map.MapElements.Add(polyline);                

        }
    }

}