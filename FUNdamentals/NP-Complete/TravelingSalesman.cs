using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FUNdamentals.NP_Complete
{
    public class TravelingSalesman
    {
        private List<Point> BestSolution;
        private double BestDistance;
        public List<Point> BruteForce(Point startingPoint, List<Point> unorderedList)
        {
            BestSolution = new List<Point>();
            BestDistance = double.MaxValue;
            CalculateRemainingPoints(new List<Point> { startingPoint }, unorderedList);
            return BestSolution;
        }

        private void CalculateRemainingPoints(List<Point> currentOrder, List<Point> remaining)
        {
            // Base Case
            if(remaining.Count == 0)
            {
                double distance = 0;
                for(int i=1; i<currentOrder.Count; i++)
                {
                    double deltaX = currentOrder[i].X - currentOrder[i - 1].X;
                    double deltaY = currentOrder[i].Y - currentOrder[i - 1].Y;
                    distance += Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                } 
                if(distance < BestDistance)
                {
                    BestDistance = distance;
                    BestSolution = currentOrder;
                }

                return;
            }

            // Recursive case
            foreach(var point in remaining)
            {
                var copiedList = new List<Point>();
                copiedList.AddRange(currentOrder);
                var copiedRemaining = new List<Point>();
                copiedRemaining.AddRange(remaining);

                copiedList.Add(point);
                copiedRemaining.Remove(point);
                CalculateRemainingPoints(copiedList, copiedRemaining);
            }
        }
    }
}
