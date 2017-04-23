using System;
using System.Collections.Generic;
using System.Drawing;
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
                    Map[x].Add(new GridNode() { Location = new Point(x, y) });
                }
            }
            PopulateNeighbors();
        }

        public Grid(List<string> rows)
        {
            Map = new List<List<GridNode>>();
            int numRows = 0;
            foreach (var r in rows)
            {
                Map.Add(new List<GridNode>());
                int numChars = 0;
                foreach(var c in r)
                {
                    Map[numRows].Add(contents.Contains(c) ? new GridNode(c.ToString()) { Location = new Point(numRows, numChars) } : new GridNode() { Location = new Point(numRows, numChars) });
                    numChars++;
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

        public GridNode this [int x, int y] => Map.ElementAtOrDefault(x)?.ElementAtOrDefault(y); // return val or null if not available

        private static readonly double CornerDistance = Math.Sqrt(2);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var list in Map)
            {
                foreach(var c in list)
                {
                    sb.Append(c.Name);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public Point? StartingLocation => GetFirstLocationOf("S");
        public Point? EndingLocation => GetFirstLocationOf("F");

        public Point? GetFirstLocationOf(string s)
        {
            int x = 0; int y = 0;
            foreach (var list in Map)
            {
                foreach (var c in list)
                {
                    if (c.Name == s)
                        return new Point(x, y);
                    y++;
                }
                y = 0;
                x++;
            }
            return null;
        }

        public class GridNode : Node
        {
            private static char[] contents = new char[] { ' ', 'S', 'F', '■', 'x' };
            public Node North     { get { return Neighbors[0].Node; } set { Neighbors[0].Node = value; } }
            public Node NorthEast { get { return Neighbors[1].Node; } set { Neighbors[1].Node = value; } }
            public Node East      { get { return Neighbors[2].Node; } set { Neighbors[2].Node = value; } }
            public Node SouthEast { get { return Neighbors[3].Node; } set { Neighbors[3].Node = value; } }
            public Node South     { get { return Neighbors[4].Node; } set { Neighbors[4].Node = value; } }
            public Node SouthWest { get { return Neighbors[5].Node; } set { Neighbors[5].Node = value; } }
            public Node West      { get { return Neighbors[6].Node; } set { Neighbors[6].Node = value; } }
            public Node NorthWest { get { return Neighbors[7].Node; } set { Neighbors[7].Node = value; } }

            public GridNode(string value = " ") : base(value)
            {
                Neighbors = new List<Vertex>()
                {
                    new Vertex { Node = null, Weight = 1d },             //North
                    new Vertex { Node = null, Weight = CornerDistance }, //NorthEast
                    new Vertex { Node = null, Weight = 1d },             //East
                    new Vertex { Node = null, Weight = CornerDistance }, //SouthEast
                    new Vertex { Node = null, Weight = 1d },             //South
                    new Vertex { Node = null, Weight = CornerDistance }, //SouthWest
                    new Vertex { Node = null, Weight = 1d },             //West
                    new Vertex { Node = null, Weight = CornerDistance }  //NorthWest
                };
            }

            public Point Location;
        }
    }
}
