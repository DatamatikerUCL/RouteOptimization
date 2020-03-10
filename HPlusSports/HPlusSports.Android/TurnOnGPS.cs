using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(HPlusSports.Droid.TurnOnGPS))]

namespace HPlusSports.Droid
{
    public class TurnOnGPS : ITurnOnGPS
    {
        [Obsolete]
        public async void turnOnGPS()
        {
            try
            {
                LocationManager locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

                //if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
                //{
                    MainActivity activity = Forms.Context as MainActivity;

                    GoogleApiClient googleApiClient = new GoogleApiClient.Builder(activity)
                        .AddApi(LocationServices.API).Build();
                    googleApiClient.Connect();
                    LocationRequest locationRequest = LocationRequest.Create();
                    locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
                    locationRequest.SetInterval(10000);
                    locationRequest.SetFastestInterval(10000 / 2);

                    LocationSettingsRequest.Builder
                            locationSettingsRequestBuilder = new LocationSettingsRequest.Builder()
                            .AddLocationRequest(locationRequest);
                    locationSettingsRequestBuilder.SetAlwaysShow(false);
                    LocationSettingsResult locationSettingsResult = await LocationServices.SettingsApi.CheckLocationSettingsAsync(
                        googleApiClient, locationSettingsRequestBuilder.Build());

                    if (locationSettingsResult.Status.StatusCode == LocationSettingsStatusCodes.ResolutionRequired)
                    {
                        locationSettingsResult.Status.StartResolutionForResult(activity, 0);
                    }
               // }
                
            }
            catch (Exception ex)
            {
               // GlobalVariables.SendExceptionReport(ex);
            }
        }
    }
}