using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Repositories
{
    public class RouteRepo
    {
        public RouteRepo()
        {

        }

        private static readonly object padLock = new object();
        private static RouteRepo instance = null;
        public static RouteRepo Instance
        {
            get
            {
                lock (padLock)
                {
                    if( instance == null)
                    {
                        instance = new RouteRepo();
                    }
                    return instance;
                }
            }
        }


    }
}
