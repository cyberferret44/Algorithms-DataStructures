using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class QuickSelect
    {
        //public static void Main()
        //{
        //    Random random = new Random();
        //    Stopwatch s1 = new Stopwatch();
        //    Stopwatch s2 = new Stopwatch();

        //    var l1 = new List<int>();
        //    for (int n = 0; n < 1000000; n++)
        //        l1.Add(random.Next());
        //    var l2 = new List<int>();
        //    for (int n = 0; n < 1000000; n++)
        //        l2.Add(random.Next());

        //    s1.Start();
        //    QuickSelectKSmallestValue(l1, 5); // O(2n)
        //    s1.Stop();
        //    Console.WriteLine(s1.ElapsedTicks);


        //    s2.Start();
        //    l2.OrderBy(x => x).First(); // nlgn
        //    s2.Stop();
        //    Console.WriteLine(s2.ElapsedTicks);

        //    Console.WriteLine("my stuff ran " + (s2.ElapsedTicks / s1.ElapsedTicks) + " times faster");

        //    Console.Read();
        //}

        public static int QuickSelectKSmallestValue(List<int> list, int k)
        {
            if (k < 0 || k > list.Count || list == null)
            {
                throw new Exception("bad input");
            }
            int start = 0;
            int end = list.Count;

            while (true) //todo add condition
            {
                int pivotIndex = start;
                for (int i = pivotIndex + 1; i < end; i++)
                {
                    if (list[i] < list[pivotIndex])
                    {
                        // put this element in front of the pivot
                        int temp = list[pivotIndex];
                        list[pivotIndex] = list[i];
                        list[i] = list[pivotIndex + 1];
                        list[pivotIndex + 1] = temp;
                        pivotIndex++;
                    }
                }
                if (pivotIndex == k - 1)
                {
                    return list[pivotIndex];
                }
                else if (pivotIndex < k - 1)
                {
                    start = pivotIndex + 1;
                }
                else
                {
                    end = pivotIndex;
                }
            }
        }

        public static List<int> QuickSelectKSmallestList(List<int> list, int k)
        {
            if (k < 0 || k > list.Count || list == null)
            {
                throw new Exception("bad input");
            }
            int start = 0;
            int end = list.Count;
            Random random = new Random();

            while (true)
            {
                int pivotIndex = start;
                for (int i = pivotIndex + 1; i < end; i++)
                {
                    if (list[i] < list[pivotIndex])
                    {
                        // put this element in front of the pivot
                        int temp = list[pivotIndex];
                        list[pivotIndex] = list[i];
                        list[i] = list[pivotIndex + 1];
                        list[pivotIndex + 1] = temp;
                        pivotIndex++;
                    }
                }
                if (pivotIndex == k - 1)
                {
                    return list.GetRange(0, pivotIndex + 1);
                }
                else if (pivotIndex < k - 1)
                {
                    start = pivotIndex + 1;
                }
                else
                {
                    end = pivotIndex;
                }
            }
        }
    }
}