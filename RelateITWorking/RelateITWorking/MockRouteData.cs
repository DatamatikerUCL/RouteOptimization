﻿using RelateIT.Interfaces;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateITWorking
{
    public class MockRouteData : IDataAccessable
    {

        ImmutableList<IPlannable> routes;
        ImmutableList<ILocateable> locations;


        public MockRouteData() 
        {
           routes = ImmutableList<IPlannable>.Empty;
           locations = ImmutableList<ILocateable>.Empty;
        }

        public Route CreateRoute(string _name)
        {

            Location location1 = new Location( 55.499680, 10.096780, "Bogensevej 105");
            Location location2 = new Location(55.416680, 10.361320, "Næsby skovvænge 7");
            Location location3 = new Location(55.403450, 10.379370, "Seebladsgade 1");
            locations.Add(location1);
            locations.Add(location2);
            locations.Add(location3);


            Route route = new Route(_name, locations, locations.Count, locations[0], DateTime.Now, 5.0);

            return route;
        }
        public ImmutableList<IPlannable> GetRoutes()
        {
            routes.Add(CreateRoute("HomeToSchool"));
            return routes;

        }

    }
}
