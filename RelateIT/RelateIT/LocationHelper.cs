using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RelateIT
{
    public static class LocationHelper
    {
        public static async Task<Location> OnGetDeviceLastLocation()
        {

            return await Geolocation.GetLastKnownLocationAsync();
        }

        public static async Task<Location> OnGetCurrentLocation()
        {
            return await Geolocation.GetLocationAsync();
        }
    }
}
