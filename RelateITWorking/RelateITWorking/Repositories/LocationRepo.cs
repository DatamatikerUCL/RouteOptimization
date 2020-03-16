using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.Repositories
{
    public class LocationRepo
    {
        public LocationRepo()
        {

        }

        private static readonly object padLock = new object();
        private static LocationRepo instance = null;
        public static LocationRepo Instance
        {
            get
            {
                lock (padLock)
                {
                    if (instance == null)
                    {
                        instance = new LocationRepo();
                    }
                    return instance;
                }
            }
        }
    }
}
