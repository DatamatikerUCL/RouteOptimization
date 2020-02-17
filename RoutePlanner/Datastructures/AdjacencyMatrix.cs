using System;
using System.Collections.Generic;

namespace RouteOptimization.RoutePlanner.Datastructures
{
    public class AdjacencyMatrix
    {
        private List<List<double>> _matrix;

        public int Size { get;}

        public AdjacencyMatrix()
        {
            _matrix = new List<List<double>>();
            Size = 0;
        }

        public AdjacencyMatrix(int size)
        {
            Size = size;
            _matrix = new List<List<double>>();

            for (int i = 0; i < size; i++)
            {
                List<double> adjacencyList = new List<double>();
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        adjacencyList.Add(0);
                    }
                    else
                    {
                        adjacencyList.Add(1);
                    }
                }

                _matrix.Add(adjacencyList);
                
            }
        }

        

        public double GetWeight(int firstCoordinate, int secondCoordinate)
        {
            return _matrix[firstCoordinate][secondCoordinate];
        }

        public void ChangeWeightAtCoordinates(int firstCoordinate, int secondCoordinate, double newWeight)
        {
            _matrix[firstCoordinate][secondCoordinate] = newWeight;
        }
    }
}