using System;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using RelateIT.Droid;
using RelateItNewest2605.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(TurnOnLocation))]
namespace RelateIT.Droid
{
    public class TurnOnLocation : ITurnOnLocation
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
    }
}