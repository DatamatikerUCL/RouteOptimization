namespace RouteOptimization.RoutePlanner.Datastructures
{
    public class Location
    {

        public Location(string address = "", double latitude = 0, double longtitude = 0)
        {
            Address = address;
            Latitude = latitude;
            Longtitude = longtitude;
        }

        public string Address { get; }
        public double Latitude { get; }

        public double Longtitude {get; }
    }
}