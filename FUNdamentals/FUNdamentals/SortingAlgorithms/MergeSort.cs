using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.SortingAlgorithms
{
    class MergeSort
    {
        public static List<T> Sort<T>(List<T> list) where T : IComparable
        {
            List<Queue<T>> result = new List<Queue<T>>();
            list.ForEach(x => result.Add(new Queue<T>(new List<T> { x })));
            while (result.Count > 1)
            {
                var newQueue = new Queue<T>();
                var q1 = result[0];
                var q2 = result[1];

                while (q1.Count > 0 && q2.Count > 0)
                {
                    newQueue.Enqueue(q1.Peek().CompareTo(q2.Peek()) <= 0 ? q1.Dequeue() : q2.Dequeue());
                }
                if (q1.Count > 0)
                    q1.ToList().ForEach(x => newQueue.Enqueue(x));
                if (q2.Count > 0)
                    q2.ToList().ForEach(x => newQueue.Enqueue(x));
                result.Remove(q1);
                result.Remove(q2);
                result.Add(newQueue);
            }
            return result.Count == 0 ? new List<T>() : result[0].ToList();
        }
    }
}
