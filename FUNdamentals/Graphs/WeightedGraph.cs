using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Graphs
{
    public class WeightedGraph
    {
    }

    public class Node
    {
        public string Name;
        protected List<Vertex> Neighbors;
        public Node(string name)
        {
            Name = name;
            Neighbors = new List<Vertex>();
        }
        protected class Vertex
        {
            public double Weight;
            public Node Neighbor;
        }
    }
}
