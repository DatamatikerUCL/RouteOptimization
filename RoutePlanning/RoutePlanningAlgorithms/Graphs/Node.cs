using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanning.RoutePlanningAlgorithms.Graphs
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }
    }
}
