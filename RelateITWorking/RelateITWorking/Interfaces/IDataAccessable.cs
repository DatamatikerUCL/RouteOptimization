using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateIT.Interfaces
{
    public interface IDataAccessable
    {

        ImmutableList<Route> GetRoutes();
    }
}
