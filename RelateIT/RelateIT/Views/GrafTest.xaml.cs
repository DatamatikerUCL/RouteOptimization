using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microcharts.Forms;
using Microcharts;
using Xamarin.Forms.Xaml;

namespace RelateIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrafTest : ContentPage
    {
        public GrafTest()
        {
            InitializeComponent();

            Chart1.Chart = new RadialGaugeChart { Entries = entries };
            Chart2.Chart = new BarChart { Entries = entries };
            Chart3.Chart = new Microcharts.DonutChart { Entries = entries };
            Chart4.Chart = new Microcharts.PointChart { Entries = entries };
            Chart5.Chart = new Microcharts.RadarChart { Entries = entries };
            Chart6.Chart = new Microcharts.LineChart { Entries = entries };

            Chart1.Chart.LabelTextSize = 30;
            Chart2.Chart.LabelTextSize = 30;
            Chart3.Chart.LabelTextSize = 30;
            Chart4.Chart.LabelTextSize = 30;
            Chart5.Chart.LabelTextSize = 30;
            Chart6.Chart.LabelTextSize = 30;
        }
        List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(200)
            {
                Color = SkiaSharp.SKColor.Parse("#FF1493"),
                Label = "Janaury",
                ValueLabel = "200"
            },
            new Microcharts.Entry(400)
            {
                Color = SkiaSharp.SKColor.Parse("#00BFFF"),
                Label = "Febuary",
                ValueLabel = "400"
            },
            new Microcharts.Entry(-100)
            {
                Color = SkiaSharp.SKColor.Parse("#00CED1"),
                Label = "March",
                ValueLabel = "-100"
            }
        };
       

    }
}
