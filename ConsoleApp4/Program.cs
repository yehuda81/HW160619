using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {        
        static void Main(string[] args)
        {
            Task<int> t = new Task<int>(() => new Random().Next(1000,2000));
            t.Start();
            Thread.Sleep(t.Result);            
            Task<int> t2 = new Task<int>(() => new Random().Next(1000, 2000));
            t2.Start();
            Thread.Sleep(t2.Result);
            Task.WaitAny(t, t2);
            Console.WriteLine(t.Result);
            Console.WriteLine(t2.Result);
        }
    }
}
