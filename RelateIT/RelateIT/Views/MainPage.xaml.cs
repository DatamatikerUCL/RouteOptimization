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
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.374181, 10.403406), Distance.FromKilometers(2)));
            BackgroundColor = Constants.BackgroundColor;
        }

        public MainPage(int id)
        {
            InitializeComponent();
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.374181, 10.403406), Distance.FromKilometers(2)));
            BackgroundColor = Constants.BackgroundColor;
        }

    private async void Btn_RouteOverView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrafTest());
        }

        private async void Btn_CreateNewRoute_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < Map.Pins.Count - 1; i++)
            {
                Position tempA = new Position(Map.Pins[i].Position.Latitude, Map.Pins[i].Position.Longitude);
                Position tempB = new Position(Map.Pins[i+1].Position.Latitude, Map.Pins[i+1].Position.Longitude);
                string json = await Services.MapFunctionHelper.GetDirectionJsonAsync(tempA, tempB);
                DrawTripOnMap(json);
            }
            //string json = await Services.MapFunctionHelper.GetDirectionJsonAsync(55.374181, 10.403406, 55.403772, 10.379840);
            //string json = await Services.MapFunctionHelper.GetDirectionJsonAsync(55.374181, 10.403406, 55.403772, 10.379840);
          
        }
        private void DrawTripOnMap(string json)
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

        private async void ToolbarItem_Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

        private async void tb_logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            Map.Pins.Add(new Pin
            {
                Label = "Pin from tap",
                Position = e.Position 
            }); 
        }

        private async void tb_refresh_Clicked(object sender, EventArgs e)
        {
            var vUpdatedPage = new MainPage();
            Navigation.InsertPageBefore(vUpdatedPage, this);
            await Navigation.PopAsync();
        }
    }

}