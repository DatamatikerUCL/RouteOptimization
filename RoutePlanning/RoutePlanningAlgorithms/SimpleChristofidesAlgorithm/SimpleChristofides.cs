using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanning.RoutePlanningAlgorithms.SimpleChristofidesAlgorithm
{
    public class SimpleChristofides : IRoutePlanner
    {
        public IPlannable PlanIPlannable(IPlannable plannable, IPlannableFactory factory)
        {
            // Select Root vertex
            ILocateable root = GetRoot(plannable);
            
            // Computer minnimum spanning tree T for G with root r using Prim's.
            

            // Let H be a list of vertices ordered according to when they are first visited in a preorder tree walk of T.

            // Return H
            throw new NotImplementedException();
        }

        private ILocateable GetRoot(IPlannable plannable)
        {
            return plannable.StartLocation;
        }
    }
}
