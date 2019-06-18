using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static ManualResetEvent Gate = new ManualResetEvent(false);
        static void Main(string[] args)
        {
           
            //Task t = new Task(ConnectToDB);            
            //t.Start();
            //t.Wait();
            new Thread(() => ConnectToDB()).Start();
            new Thread(() => CreateCustomer()).Start();
            new Thread(() => DelateOrder()).Start();            
            

           
        }

        private static void ConnectToDB()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Conecting to Date Base");
            Gate.Set();
        }

        private static void DelateOrder()
        {
            Gate.WaitOne();
            Console.WriteLine("Order has been delated!");
        }

        private static void CreateCustomer()
        {
            Gate.WaitOne();
            Console.WriteLine("Customer created!");
        }
    }
}
