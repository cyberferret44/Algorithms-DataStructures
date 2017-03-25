using PracticeQuestions.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree<int> tree = new BinarySearchTree<int>();
            //tree.Insert(10);
            //tree.Insert(20);
            //tree.Insert(30);
            //tree.Insert(30);
            //tree.Insert(15);
            //tree.Insert(5);
            //tree.Insert(8);
            //tree.Insert(0);

            //if(!tree.GetInOrderTraversal().SequenceEqual(new List<int> { 0, 5, 8, 10, 15, 20, 30, 30}))
            //{
            //    throw new Exception();
            //}

            //tree.Delete(30);
            //tree.Delete(10);

            //if (!tree.GetInOrderTraversal().SequenceEqual(new List<int> { 0, 5, 8, 15, 20}))
            //{
            //    throw new Exception();
            //}

            //Console.ReadLine();

            foreach (var i in GetTwoHighest(new List<int> { 65, 2, 68, 90, 3, 54, 7000 }))
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }

        public static IEnumerable<int> GetTwoHighest(List<int> list)
        {
            list = list.OrderByDescending(x => x).ToList();
            yield return list[0];
            yield return list[1];
        }
    }
}
