using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FUNdamentals.InterviewQuestions
{
    /// <summary>
    /// Given a list of Points (x,y) on a cartesian coordinate plane, and an integer K,
    /// return a list of size K containing the K points closest to the origin (0,0)
    /// </summary>
    class PointsQuestion
    {
        // O(nlg(n))
        public static List<Point> GetKNearestSorting(List<Point> points, int k)
        {
            return points?.OrderBy(p => Math.Sqrt(p.X * p.X + p.Y * p.Y)).Take(Math.Min(points.Count, k)).ToList() ?? new List<Point>();
        }

        // O(nlg(k)
        // It's faster and (likely) more space efficient than outright sorting
        public static List<Point> GetKNearest(List<Point> points, int k)
        {
            if (k == 0)
                return new List<Point>();

            var result = new List<Tuple<double, Point>>();
            foreach (var p in points)
            {
                double distance = Math.Sqrt(p.X * p.X + p.Y * p.Y);
                if (result.Count < k)
                {
                    SortedInsert(result, Tuple.Create(distance, p)); // inserts in lg(k)
                }
                else if (distance < result[k - 1].Item1)
                {
                    result.RemoveAt(k - 1);
                    SortedInsert(result, Tuple.Create(distance, p)); // inserts in lg(k)
                }
            }

            return result.Select(x => x.Item2).ToList();
        }

        // List will maintain a sort order of smallest to largest distance
        private static void SortedInsert(List<Tuple<double, Point>> list, Tuple<double, Point> newValue)
        {
            int index = list.Count / 2;

            while (true)
            {
                if (index == 0 || index == list.Count)
                    break;
                if (list[index - 1].Item1 > newValue.Item1)
                    index /= 2;
                else if (list[index].Item1 < newValue.Item1)
                    index += (list.Count + 1 - index) / 2;
                else
                    break;
            }

            list.Insert(index, newValue);
        }
    }
}
