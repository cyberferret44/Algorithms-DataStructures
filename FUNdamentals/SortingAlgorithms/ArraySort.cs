using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.SortingAlgorithms
{
    public class ArraySort
    {
        /// <summary>
        /// Against 10,000,000 entries, this method versus Linq's OrderBy for sorting a list of ints between 1 - 130...
        /// This: ~100 miliseconds
        /// Linq: ~5000 miliseconds
        /// </summary>
        public static int[] Sort(int[] original)
        {
            int[] counts = Enumerable.Repeat(0, 150).ToArray();

            foreach(var i in original)
            {
                counts[i]++;
            }

            int[] result = new int[original.Length];
            int index = 0;
            for (int val = 0; val < counts.Length; val++)
            {
                for(int i=0; i<counts[val]; i++)
                {
                    result[index] = val;
                    index++;
                }
            }
            return result;
        }
    }
    /*
     * Random r = new Random();
            int[] unsortedArray = new int[10000000];
            for(int i=0; i<10000000; i++)
            {
                unsortedArray[i] = r.Next(0, 130);
            }
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            ArraySort.Sort(unsortedArray);
            s1.Stop();
            Console.WriteLine($"array sort sorted in {s1.ElapsedMilliseconds} miliseconds.");


            Stopwatch s2 = new Stopwatch();
            s2.Start();
            var r4 = unsortedArray.OrderBy(x => x).ToArray();
            s2.Stop();
            Console.WriteLine($"Linq sorted in {s2.ElapsedMilliseconds} miliseconds.");
            Console.Read();*/
}
