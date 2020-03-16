using RelateIT.Models;
using RelateIT.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.ViewModel
{
    public class RouteViewModel
    {
        private RouteRepo routeRepo = RouteRepo.GetInstance;
        private List<Route> routes = new List<Route>();


        public List<Route> GetRoutes()
        {
            return routes = routeRepo.GetRoutes();
        }
    }
}
