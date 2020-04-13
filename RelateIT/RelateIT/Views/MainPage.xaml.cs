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

            Xamarin.Forms.Maps.Polyline polyline = new Xamarin.Forms.Maps.Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 12,
                Geopath =
                {
                   new Position(directionData.routes[0].legs[0].steps[0].start_location.lat, directionData.routes[0].legs[0].steps[0].start_location.lng),
                   new Position(directionData.routes[0].legs[0].steps[0].end_location.lat, directionData.routes[0].legs[0].steps[0].end_location.lng)
                }


                
                
            };
            
            ;

            Map.MapElements.Add(polyline);


        }
    }

}