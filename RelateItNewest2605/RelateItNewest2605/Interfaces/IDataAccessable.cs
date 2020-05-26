using RelateItNewest2605.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateItNewest2605.Interfaces
{
    public interface IDataAccessable
    {

        ImmutableList<Route> GetRoutes();
    }
}
