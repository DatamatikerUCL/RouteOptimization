using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Xamarin.Forms;

namespace RelateIT.Models
{
    public class RoutePlanned : IPlannable
    {
        public string Name { get; set; }

        public ImmutableList<ILocateable> Locations { get; }

        public int LocationCount { get => Locations.Count;}

        public ILocateable StartLocation {get => Locations[0]; }


        public RoutePlanned(string _name, ImmutableList<ILocateable> _locations, int _locationCount, ILocateable _startLocation)
        {
            Name = _name;
            Locations = _locations;

        }
    }
}
