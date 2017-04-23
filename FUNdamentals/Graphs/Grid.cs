using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Graphs
{
    public class Grid
    {
        private List<List<GridNode>> Map;
        private static char[] contents = new char[] { ' ', 'S', 'F', '█', 'x' };

        public Grid(int height, int width)
        {
            Map = new List<List<GridNode>>();
            for (int x = 0; x < width; x++)
            {
                Map.Add(new List<GridNode>());
                for (int y = 0; y < height; y++)
                {
                    Map[x].Add(new GridNode());
                }
            }
            PopulateNeighbors();
        }

        public Grid(List<string> rows)
        {
            Map = new List<List<GridNode>>();
            foreach(var r in rows)
            {
                Map.Add(new List<GridNode>());
                int numRows = 0;
                foreach(var c in r)
                {
                    Map[numRows].Add(contents.Contains(c) ? new GridNode(c.ToString()) : new GridNode());
                }
                numRows++;
            }
            PopulateNeighbors();
        }

        private void PopulateNeighbors()
        {
            for(int x=0; x<Map.Count; x++)
            {
                for(int y=0; y<Map[x].Count; y++)
                {
                    var node = (GridNode)this[x, y];
                    node.North = this[x, y - 1];
                    node.NorthEast = this[x + 1, y - 1];
                    node.East = this[x + 1, y];
                    node.SouthEast = this[x + 1, y + 1];
                    node.South = this[x, y + 1];
                    node.SouthWest = this[x - 1, y + 1];
                    node.West = this[x - 1, y];
                    node.NorthWest = this[x - 1, y - 1];
                }
            }
        }

        public Node this [int x, int y] => Map.ElementAtOrDefault(x)?.ElementAtOrDefault(y); // return val or null if not available

        private static readonly double CornerDistance = Math.Sqrt(2);
        private class GridNode : Node
        {
            private static char[] contents = new char[] { ' ', 'S', 'F', '■', 'x' };
            public Node North     { get { return Neighbors[0].Neighbor; } set { Neighbors[0].Neighbor = value; } }
            public Node NorthEast { get { return Neighbors[1].Neighbor; } set { Neighbors[1].Neighbor = value; } }
            public Node East      { get { return Neighbors[2].Neighbor; } set { Neighbors[2].Neighbor = value; } }
            public Node SouthEast { get { return Neighbors[3].Neighbor; } set { Neighbors[3].Neighbor = value; } }
            public Node South     { get { return Neighbors[4].Neighbor; } set { Neighbors[4].Neighbor = value; } }
            public Node SouthWest { get { return Neighbors[5].Neighbor; } set { Neighbors[5].Neighbor = value; } }
            public Node West      { get { return Neighbors[6].Neighbor; } set { Neighbors[6].Neighbor = value; } }
            public Node NorthWest { get { return Neighbors[7].Neighbor; } set { Neighbors[7].Neighbor = value; } }

            public GridNode(string value = " ") : base(value)
            {
                Neighbors = new List<Vertex>()
                {
                    new Vertex { Neighbor = null, Weight = 1d },             //North
                    new Vertex { Neighbor = null, Weight = CornerDistance }, //NorthEast
                    new Vertex { Neighbor = null, Weight = 1d },             //East
                    new Vertex { Neighbor = null, Weight = CornerDistance }, //SouthEast
                    new Vertex { Neighbor = null, Weight = 1d },             //South
                    new Vertex { Neighbor = null, Weight = CornerDistance }, //SouthWest
                    new Vertex { Neighbor = null, Weight = 1d },             //West
                    new Vertex { Neighbor = null, Weight = CornerDistance }  //NorthWest
                };
            }

            public bool IsPassable => Name != "■";
        }
    }
}
