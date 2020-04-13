using Newtonsoft.Json;
using RelateIT.Services;
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
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(55.374181, 10.403406), Map.VisibleRegion.Radius));
        }
            
        public MainPage(int id)
        {
            InitializeComponent();
        }

        private void Btn_RouteOverView_Clicked(object sender, EventArgs e)
        {

        }

        private async void Btn_CreateNewRoute_Clicked(object sender, EventArgs e)
        {            
            string json = await Services.MapFunctionHelper.GetDirectionJsonAsync(55.374181, 10.403406, 55.403772, 10.379840);
            DrawTripOnMap(json);
        }
        public void DrawTripOnMap(string json)
        {
            var directionData = JsonConvert.DeserializeObject<RootObject>(json);

            var route = new List<Position>();

            foreach (var item in directionData.routes[0].legs[0].steps)
            {
                Position tempStart = new Position(item.start_location.lat, item.start_location.lng);
                Position tempEnd = new Position(item.end_location.lat, item.end_location.lng);

                route.Add(tempStart);
                route.Add(tempEnd);
            }


            Xamarin.Forms.Maps.Polyline polyline = new Xamarin.Forms.Maps.Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
                Geopath =
                {
                    new List<Position> = route
                }
                        

            };
            
            ;

            Map.MapElements.Add(polyline);


        }
    }

}