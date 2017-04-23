using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static FUNdamentals.Graphs.Grid;

namespace FUNdamentals.Graphs
{
    public class DijkstrasTraversal
    {
        public static void FindAndPopulatePath(Grid grid)
        {
            if(!grid.StartingLocation.HasValue || !grid.EndingLocation.HasValue)
            {
                return;
            }

            Point start = grid.StartingLocation.Value;
            Point end = grid.EndingLocation.Value;

            HashSet<Point> visitedNodes = new HashSet<Point>();

            SortedList<SpecialDouble, Data> queue = new SortedList<SpecialDouble, Data>();

            queue.Add(new SpecialDouble(0.0), new Data(start, new List<Point>()));

            while(queue.Any())
            {
                var lowest = queue.First();
                queue.RemoveAt(0);
                if(lowest.Value.Location == end)
                {
                    drawPath(grid, lowest.Value.Path);
                    return;
                }

                visitedNodes.Add(lowest.Value.Location);
                List<Point> newList = lowest.Value.Path.Select(x => x).ToList();
                newList.Add(lowest.Value.Location);
                foreach (var neighbor in grid[lowest.Value.Location.X, lowest.Value.Location.Y].ValidNeighbors.Where(x => IsPassable(x.Node) && !visitedNodes.Contains(((GridNode)x.Node).Location)))
                {
                    queue.Add(new SpecialDouble(lowest.Key.Value + neighbor.Weight), new Data(((GridNode)neighbor.Node).Location, newList));
                }
            }
            return;
        }

        private class SpecialDouble : IComparable
        {
            public SpecialDouble(double value)
            {
                Value = value;
            }
            public double Value;
            public int CompareTo(object obj)
            {
                int result = Value.CompareTo(((SpecialDouble)obj).Value);
                return result == 0 ? 1 : result;
            }
        }

        private class Data
        {
            public Data(Point loc, List<Point> path)
            {
                Location = loc;
                Path = path.Select(x => x).ToList();
            }
            public Point Location;
            public List<Point> Path;
        }

        public static bool IsPassable(Node n) => n.Name != "█";

        public static void drawPath(Grid grid, List<Point> pointsTraversed)
        {
            foreach(var p in pointsTraversed)
            {
                grid[p.X, p.Y].Name = grid[p.X, p.Y].Name == " " ? "x" : grid[p.X, p.Y].Name;
            }
        }
    }
}
