using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.InterviewQuestions
{
    public class FindLongestRecurringSubstring
    {

        public static void Find(string input)
        {
            int[] suffixArray = GetSuffixArray(input);
            suffixArray = SortSuffixArray(suffixArray, input);

            int max = -1;
            int indexOfMax = -1;

            for(int i=0; i < suffixArray.Length - 1; i++)
            {
                int index1 = suffixArray[i];
                int index2 = suffixArray[i + 1];
                int currentIndex = 0;
                while(index1 + currentIndex < input.Length && index2 + currentIndex < input.Length && input[index1 + currentIndex] == input[index2 + currentIndex])
                {
                    currentIndex++;
                }
                if(currentIndex > max)
                {
                    indexOfMax = index1;
                    max = currentIndex;
                }
            }

            Console.WriteLine($"the longest recurring substring was '{input.Substring(indexOfMax, max)}'");
        }

        private static int[] GetSuffixArray(string input)
        {
            int[] suffixArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                suffixArray[i] = i;
            }
            return suffixArray;
        }

        /// <summary>
        /// the indexes represent possible starting points in the original string.
        /// we want to sort the indexes representing the substrings such that they are alphabetical.
        /// Thus the input string "cat" would have the substrings "cat", "at", and "t"
        /// would be sorted ["at", "cat", "t"] ... thus the suffix array will be [1, 0, 2] after this method.
        /// 
        /// The sorting method will be a special implementation of merge sort.
        /// </summary>
        private static int[] SortSuffixArray(int[] unsorted, string input)
        {
            Queue<List<int>> queue = new Queue<List<int>>();
            foreach(int i in unsorted)
            {
                var newList = new List<int> { i };
                queue.Enqueue(newList);
            }

            while(queue.Count > 1)
            {
                List<int> newList = new List<int>();
                var l1 = queue.Dequeue();
                var l2 = queue.Dequeue();
                int l1Index = 0;
                int l2Index = 0;
                while(l1Index < l1.Count && l2Index < l2.Count)
                {
                    if(IsBefore(l1[l1Index], l2[l2Index], input))
                    {
                        newList.Add(l1[l1Index]);
                        l1Index++;
                    }
                    else
                    {
                        newList.Add(l2[l2Index]);
                        l2Index++;
                    }
                }
                while (l1Index < l1.Count)
                {
                    newList.Add(l1[l1Index]);
                    l1Index++;
                }
                while (l2Index < l2.Count)
                {
                    newList.Add(l2[l2Index]);
                    l2Index++;
                }
                queue.Enqueue(newList);
            }

            return queue.Dequeue().ToArray();
        }

        private static bool IsBefore(int i1, int i2, string input)
        {
            string s1 = input.Substring(i1);
            string s2 = input.Substring(i2);
            return s1.CompareTo(s2) < 0;
        }
    }
}
