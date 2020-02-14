namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IRoutePlanner
    {
        OrderedRoute PlanRoute(UnorderedRoute routeToPlan);
    }
}