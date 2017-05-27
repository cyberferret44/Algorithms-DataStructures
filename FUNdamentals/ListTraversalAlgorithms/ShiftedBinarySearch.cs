using System;

namespace Learn
{
    class ShiftedBinarySearch
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { }, 1)); // false
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 1 }, 1)); // true
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 2, 3 }, 1)); // false
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3 }, 1)); // false
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3 }, 1)); // false
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3 }, 10)); // false
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 0)); // true
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 13)); // true
        //    Console.WriteLine(BinarySearchContains<int>(new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 14)); // false
        //    Console.Read();
        //}

        public static bool BinarySearchContains<T>(T[] sortedItems, T value) where T : IComparable
        {
            int currentIndex = sortedItems.Length / 2;
            int lowRange = 0; // inclusive
            int highRange = sortedItems.Length; // non-inclusive

            while (lowRange != highRange)
            {
                int compareValue = sortedItems[currentIndex].CompareTo(value);
                if (compareValue < 0)
                {
                    lowRange = currentIndex + 1;
                    currentIndex = currentIndex + (highRange - currentIndex) / 2;
                }
                else if (compareValue > 0)
                {
                    highRange = currentIndex;
                    currentIndex = currentIndex / 2;
                }
                else
                    return true;
            }

            return false;
        }
    }
}