using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Concurrency
{
    class Mutex
    {
        public interface Bank
        {
            decimal Withdraw(decimal Amount);
            decimal Deposit(decimal Amount);
        }

        public class BadBankAccount : Bank
        {
            public decimal Balance = 0;
            public decimal Withdraw(decimal Amount)
            {
                decimal currentBalance = Balance - Amount;
                if (currentBalance < 0)
                    throw new Exception("Insufficient Funds!");

                System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something

                Balance = currentBalance;
                return Balance;

            }
            public decimal Deposit(decimal Amount)
            {
                decimal newBalance = Balance + Amount;
                System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something
                Balance = newBalance;
                return Balance;
            }
        }

        public class GoodBankAccount : Bank
        {
            public decimal Balance = 0;
            private object _lock = new object();
            public decimal Withdraw(decimal Amount)
            {
                lock(_lock)
                {
                    decimal currentBalance = Balance - Amount;
                    if (currentBalance < 0)
                        throw new Exception("Insufficient Funds!");

                    System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something

                    Balance = currentBalance;
                    return Balance;
                }
            }
            public decimal Deposit(decimal Amount)
            {
                lock(_lock)
                {
                    decimal currentBalance = Balance + Amount;
                    System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something
                    Balance = currentBalance;
                    return Balance;
                }
            }
        }

        public class GoodBankAccount2 : Bank
        {
            public decimal Balance = 0;
            System.Threading.Mutex mutex = new System.Threading.Mutex();
            public decimal Withdraw(decimal Amount)
            {
                mutex.WaitOne();
                try
                {
                    decimal currentBalance = Balance - Amount;
                    if (currentBalance < 0)
                        throw new Exception("Insufficient Funds!");

                    System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something

                    Balance = currentBalance;
                    mutex.ReleaseMutex();
                    return Balance;
                }
                catch(Exception e)
                {
                    mutex.ReleaseMutex();
                    throw e;
                }
                
            }
            public decimal Deposit(decimal Amount)
            {
                mutex.WaitOne();
                try
                {
                    decimal currentBalance = Balance + Amount;
                    System.Threading.Thread.Sleep(100); // pretend we're waiting on verification or something
                    Balance = currentBalance;
                    mutex.ReleaseMutex();
                    return Balance;
                }
                catch (Exception e)
                {
                    mutex.ReleaseMutex();
                    throw e;
                }
            }
        }
    }
    //bad.Deposit(300);
    //        var t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawBad));
    //var t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawBad));
    //t1.Start(); t2.Start();

    //        System.Threading.Thread.Sleep(1000);
    //        Console.WriteLine(bad.Balance);

    //        //**************************
    //        good1.Deposit(3000);
    //        t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood1));
    //        t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood1));
    //        t1.Start(); t2.Start();

    //        System.Threading.Thread.Sleep(1000);
    //        Console.WriteLine(good1.Balance);

    //        //**************************
    //        good2.Deposit(30000);
    //        t1 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood2));
    //        t2 = new System.Threading.Thread(new System.Threading.ThreadStart(WithdrawGood2));
    //        t1.Start(); t2.Start();

    //        System.Threading.Thread.Sleep(1000);
    //        Console.WriteLine(good2.Balance);

    //        Console.Read();
}
