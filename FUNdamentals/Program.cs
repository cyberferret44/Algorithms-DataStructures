using FUNdamentals.Concurrency;
using FUNdamentals.SortingAlgorithms;
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

            //foreach (var i in GetTwoHighest(new List<int> { 65, 2, 68, 90, 3, 54, 7000 }))
            //{
            //    Console.WriteLine(i);
            //}

            //var list = QuickSort.Sort<int>(new List<int> { 86, 45, 2, 4, 98, 92, 5, 6, 89, 6, 8, 9 }.ToArray());
            //Console.WriteLine(list);
            //Console.Read();
            
            bad.Deposit(300);
            var t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawBad));
            var t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawBad));
            t1.Start(); t2.Start();

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(bad.Balance);

            //**************************
            good1.Deposit(3000);
            t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood1));
            t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood1));
            t1.Start(); t2.Start();

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(good1.Balance);

            //**************************
            good2.Deposit(30000);
            t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood2));
            t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood2));
            t1.Start(); t2.Start();

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(good2.Balance);

            Console.Read();
        }

        static Mutex.BadBankAccount bad = new Mutex.BadBankAccount();
        static Mutex.GoodBankAccount good1 = new Mutex.GoodBankAccount();
        static Mutex.GoodBankAccount2 good2 = new Mutex.GoodBankAccount2();

        public static void WithdrawBad()
        {
            decimal amount = 250;
            bad.Withdraw(amount);
        }

        public static void WithdrawGood1()
        {
            decimal amount = 250;
            good1.Withdraw(amount);
        }

        public static void WithdrawGood2()
        {
            decimal amount = 250;
            good2.Withdraw(amount);
        }

        //public static IEnumerable<int> GetTwoHighest(List<int> list)
        //{
        //    list = list.OrderByDescending(x => x).ToList();
        //    yield return list[0];
        //    yield return list[1];
        //}
    }
}
