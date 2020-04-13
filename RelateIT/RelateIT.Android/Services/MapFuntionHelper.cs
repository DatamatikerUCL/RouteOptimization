using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Maps.Android;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace RelateIT.Droid.Services
{
    public class MapFuntionHelper
    {
        private readonly string mapKey = "AIzaSyCAFdM2qLPGB6nQeCK34zJR6eSijlnoj5k";

        public string GetGeoCoderURL(double lat, double lng)
        {
            string url = "Https://maps.googleapi.com/maps/api/gecode/json?latlng=" + lat + "," + lng + "&key=" + mapKey;
            return url;
        }
        
        public async Task<string> GetGeoJsonAsync(string url)
        {
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);
            return result;
        }

        public async Task<string> FindCordinateAddress(LatLng postition)
        {
            string url = GetGeoCoderURL(postition.Latitude, postition.Longitude);
            string json = "";
            string placeAddress = "";

            json = await GetGeoJsonAsync(url);

            if (!string.IsNullOrEmpty(json))
            {
                //var geoCodeData = JsonConvert.DeserializeObject<GeoCodingParser>(json)
            };
            return placeAddress;
        }

        public async Task<string> GetDirectionJsonAsync(LatLng location, LatLng destination)
        {
            string str_origin = "origin=" + location.Latitude + "," + location.Longitude;

            string str_destination = "destination=" + destination.Latitude + "," + destination.Longitude;

            string mode = "mode=driving";

            string parameters = str_origin + "&" + str_destination + "&" + "&" + mode;

            string output = "json";

            string key = mapKey;

            string url = "Http://maps.googleapi.com/maps/api/directions/" + output + "?" + parameters + key;

            string json = "";

            json = await GetGeoJsonAsync(url);

            return json;
        }

        public void DrawTripMap(string json)
        {
            var directionData = JsonConvert.DeserializeObject<DirectionParser>(json);

            //Decode

            var points = directionData.routes[0].overview_polyline.points;
            var line = PolyUtil.Decode(points);

            var routelist = new ArrayList();
            foreach (LatLng item in line)
            {
                routelist.Add(item);
            }

            PolylineOptions polylineOptions = new PolylineOptions();
                
                
                
        }

    }
}