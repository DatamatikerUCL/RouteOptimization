using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateIT.Interfaces
{
    interface IDataAccessable
    {

        ImmutableList<IPlannable> GetRoutes();
    }
}
