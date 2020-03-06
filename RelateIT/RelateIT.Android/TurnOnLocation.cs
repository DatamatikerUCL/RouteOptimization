using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AngleSharp.Dom;
using RelateIT.Droid;


namespace RelateIT.Droid
{
    public class TurnOnLocation : ILocation
    {
        
        
        public async void TurnOnGPS()
        {
            try
            {
                MainActivity activity = global::Xamarin.Forms.Forms.Context as MainActivity;

                GoogleApiClient googleApiClient = new GoogleApiClient.Builder(activity).AddApi(LocationServices.API).Build();
                googleApiClient.Connect();
                LocationRequest locationRequest = LocationRequest.Create();
                locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
                locationRequest.SetInterval(10000);
                locationRequest.SetFastestInterval(10000 / 2);
                LocationSettingsRequest.Builder
                    locationSettingsRequestBuilder = new LocationSettingsRequest.Builder().AddLocationRequest(locationRequest);
                locationSettingsRequestBuilder.SetAlwaysShow(false);
                LocationSettingsResult locationSettingsResult = await LocationServices.SettingsApi.CheckLocationSettingsAsync(
                    googleApiClient, locationSettingsRequestBuilder.Build());

                if (locationSettingsResult.Status.StatusCode == LocationSettingsStatusCodes.ResolutionRequired)
                {
                    locationSettingsResult.Status.StartResolutionForResult(activity, 0);
                }

                var result = await LocationServices.SettingsApi.CheckLocationSettingsAsync(googleApiClient, locationSettingsRequestBuilder.Build());
            }
            catch (Exception e)
            {
               
            }
        }


        public string Href { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Protocol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Host { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HostName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Port { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PathName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Search { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Hash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Origin => throw new NotImplementedException();

        public void Assign(string url)
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Replace(string url)
        {
            throw new NotImplementedException();
        }
    }
}