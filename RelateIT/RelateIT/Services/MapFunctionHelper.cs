using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

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
        

        public static async Task<string> GetDirectionJsonAsync(Position startposistion, Position endPosition)
        {
            string str_origin = "origin=" + startposistion.Latitude + "," + startposistion.Longitude;

            string str_destination = "destination=" + endPosition.Latitude + "," + endPosition.Longitude;

            string mode = "mode=driving";

            string parameters = str_origin + "&" + str_destination;

            string output = "json";

            string key = mapKey;

            string url = "https://maps.googleapis.com/maps/api/directions/" + output + "?" + parameters + "&&" + mode + "&key=" + key;           

            string json = await GetGeoJsonAsync(url);

            return json;
        }

       
    }
}
