using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RelateIT.UWP
{
    public sealed partial class MainPage
    {
        private readonly string authenticationKey = "NRHTK2peNSMBw6gcSJuW~qIBw5QKFs0sWR72xtTgzJg~AoG283d-lMr4E3BZ_SVS382RhY22uHUjrpnAFQdiNPaduxrTXhSNeMEOQeieuePa";
        public MainPage()
        {
            this.InitializeComponent();

            Xamarin.FormsMaps.Init(authenticationKey);
            Windows.Services.Maps.MapService.ServiceToken = authenticationKey;
            InitializeMap();

            LoadApplication(new RelateIT.App());

        }

        public void InitializeMap()
        {
            var map = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(GetDeviceLocation().Result.Latitude, GetDeviceLocation().Result.Longitude), Distance.FromKilometers(5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }

        public async Task<Location> GetDeviceLocation()
        {

            var location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }
    }
}
