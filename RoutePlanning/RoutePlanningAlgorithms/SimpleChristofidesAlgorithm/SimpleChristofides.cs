using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RoutePlanning.RoutePlanningAlgorithms.SimpleChristofidesAlgorithm
{
    public class SimpleChristofides : IRoutePlanner
    {
        private readonly IDistanceCalculator _distanceCalculator;
        public SimpleChristofides(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }
        public IPlannable PlanIPlannable(IPlannable plannable, IPlannableFactory factory)
        {
            Graph minimumSpanningTree = GetMinimumSpanningTree(plannable);

            IPlannable hamiltonianTour = GetHamiltonianTour(minimumSpanningTree, factory);

            return hamiltonianTour;
        }

        private IPlannable GetHamiltonianTour(Graph minimumSpanningTree, IPlannableFactory factory)
        {
            ImmutableList<ILocateable> orderedList = minimumSpanningTree.GetOrderedLocations();

            IPlannable hamiltonianTour = factory.NewIPlannable(orderedList);

            return hamiltonianTour;
        }

        private Graph GetMinimumSpanningTree(IPlannable plannable)
        {
            AdjacencyMatrix matrix = new AdjacencyMatrix(plannable, _distanceCalculator);

            Graph minimumSpanningTree = Prim.PrimMinimumSpanningTree(matrix, plannable.LocationCount, plannable.Locations);

            return minimumSpanningTree;
        }
    }
}
