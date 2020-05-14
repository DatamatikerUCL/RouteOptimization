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
using System.IO;
using System.Reflection;
using RelateIT.Models;

namespace RelateIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrafTest : ContentPage
    {
        private List<string> listA = new List<string>();
        private List<string> listB = new List<string>();
        private List<string> listC = new List<string>();
        private List<string> listD = new List<string>();

        private CoronaCases corona;
        public void readCSVFile()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("RelateIT.Data.corona_denmark.csv"))
            {
                using (var streamreader = new StreamReader(stream))
                {
                                     
                    while (!streamreader.EndOfStream)
                    {
                        string line = streamreader.ReadLine();
                        string[] values = line.Split(',');

                        listA.Add(values[0]);
                        listB.Add(values[1]);
                        listC.Add(values[2]);
                        listD.Add(values[3]);
                    }
                }
            }

        }
        public GrafTest()
        {
            foreach (var item in listB)
            {

            }


            InitializeComponent();
            readCSVFile();
            List<Microcharts.Entry> entries2 = new List<Microcharts.Entry>();



            listB.RemoveAt(0);
            listD.RemoveAt(0);
            foreach (var item in listB)
            {
                foreach (var item2 in listD)
                {
                    entries2.Add(new Microcharts.Entry(Convert.ToInt32(item) / 10)
                    {
                        Label = "Confirmed cases",
                        ValueLabel = item2,
                        Color = SkiaSharp.SKColor.Parse("#FF1493")
                    });
                }

            }


            Chart1.Chart = new RadialGaugeChart { Entries = entries };
            Chart2.Chart = new BarChart { Entries = entries2 };
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
