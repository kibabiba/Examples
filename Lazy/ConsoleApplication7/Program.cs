using System;
using System.Threading;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main()
        {
            var a = new Lazy<int>(() =>
            {
                Thread.Sleep(3000);
                return 2;
            });

            Console.WriteLine(DateTime.Now + " " + a.Value);
            Console.WriteLine(DateTime.Now + " " + a.Value);
            Console.WriteLine(DateTime.Now + " " + a.Value);
            Console.WriteLine(DateTime.Now + " " + a.Value);
            Console.WriteLine(DateTime.Now + " " + a.Value);

            Console.ReadKey();
        }
    }
}
