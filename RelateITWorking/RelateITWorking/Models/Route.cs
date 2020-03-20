using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Xamarin.Forms;

namespace RelateIT.Models
{
    public class Route : IPlannable
    {
        public int Id { get; }
        public string Name { get; set; }

        public ImmutableList<ILocateable> Locations { get; }

        public int LocationCount { get => Locations.Count; }

        public ILocateable StartLocation { get => Locations[0]; }

        public DateTime DateOfExecution { get; set; }

        public double EstimatedCompletionTime { get; set; }


        public Route(string _name, ImmutableList<ILocateable> _locations, int _locationCount, ILocateable _startLocation, DateTime _dateOfExecution, double _estimatedCompletionTime)
        {
            Name = _name;
            Locations = _locations;
            DateOfExecution = _dateOfExecution;
            EstimatedCompletionTime = _estimatedCompletionTime;

        }
    }
}
