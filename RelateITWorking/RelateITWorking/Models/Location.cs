﻿
using Android.OS;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RelateIT.Models
{

    public class Location : ILocateable
    {
        public double Latitude { get; }

        public double Longtitude { get; }

        public string Adress { get; set; }

        public Location(double _latitude, double _longitude, string _adress)
        {
            Latitude = _latitude;
            Longtitude = _longitude;
            Adress = _adress;
        }

        public Location(double _latitude, double _longitude)
        {
            Latitude = _latitude;
            Longtitude = _longitude;
        }


        public Location()
        {

        }

    }
}