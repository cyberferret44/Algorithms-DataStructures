using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.SortingAlgorithms
{
    public static class QuickSort
    {
        private static Random random = new Random();
        public static T[] Sort<T>(T[] list) where T : IComparable
        {
            var newList = (T[])list.Clone();
            Sort(ref newList, 0, newList.Length);
            return newList;
        }

        private static void Sort<T>(ref T[] list, int start, int end) where T : IComparable
        {
            int radix = random.Next(start, end);
            int pivot = radix;

            for(int i=start; i<radix; i++)
            {
                if(list[i].CompareTo(list[radix]) > 0)
                {
                    Swap(ref list, radix, i);
                    radix--;
                    i--;
                }
            }
            for (int i = pivot + 1; i < end; i++)
            {
                if (list[i].CompareTo(list[radix]) < 0)
                {
                    Swap(ref list, radix, i);
                    radix++;
                    i++;
                }
            }

            if (radix - start > 1)
                Sort<T>(ref list, start, radix);
            if (end - radix > 2)
                Sort<T>(ref list, radix + 1, end);
        }

        private static void Swap<T>(ref T[] list, int radix, int elem)
        {
            int interm = radix + (radix > elem ? -1 : 1);
            T temp = list[radix];
            list[radix] = list[elem];
            list[elem] = list[interm];
            list[interm] = temp;
        }
    }
}
