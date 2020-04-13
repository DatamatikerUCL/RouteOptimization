using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RelateIT.Services
{
    public static class MapFunctionHelper
    {        
        private readonly static string mapKey = "AIzaSyCAFdM2qLPGB6nQeCK34zJR6eSijlnoj5k";

        public static string GetGeoCoderURL(double lat, double lng)
        {
            string url = "Https://maps.googleapi.com/maps/api/gecode/json?latlng=" + lat + "," + lng + "&key=" + mapKey;
            return url;
        }

        public static async Task<string> GetGeoJsonAsync(string url)
        {
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);
            return result;
        }
        

        public static async Task<string> GetDirectionJsonAsync(double location_lat, double location_lng, double destination_lat, double destination_lng)
        {
            string str_origin = "origin=" + location_lat + "," + location_lng;

            string str_destination = "destination=" + destination_lat + "," + destination_lng;

            string mode = "mode=driving";

            string parameters = str_origin + "&" + str_destination;

            string output = "json";

            string key = mapKey;

            string url = "https://maps.googleapis.com/maps/api/directions/" + output + "?" + parameters + "&key=" + key;

            string json = "";

            json = await GetGeoJsonAsync(url);

            return json;
        }

       
    }
}
