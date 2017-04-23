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
        public List<Vertex> Neighbors;
        public List<Vertex> ValidNeighbors => Neighbors.Where(x => x.Node != null).ToList();
        public Node(string name)
        {
            Name = name;
            Neighbors = new List<Vertex>();
        }
        public class Vertex
        {
            public double Weight;
            public Node Node;
        }
    }
}
