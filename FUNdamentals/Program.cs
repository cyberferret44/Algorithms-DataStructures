using FUNdamentals.Concurrency;
using FUNdamentals.InterviewQuestions;
using FUNdamentals.NP_Complete;
using FUNdamentals.SortingAlgorithms;
using PracticeQuestions.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals
{
    class Program
    {
        public static void Main()
        {
            Random r = new Random();
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
            Console.Read();
        }
    }
}
