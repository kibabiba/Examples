using System;
using System.Threading;

namespace ConsoleApplication7
{
    class Program
    {
        private static readonly Lazy<int> _a = new Lazy<int>(() =>
                {
                    Thread.Sleep(3000);
                    return 2;
                });

        public static int A
        {
            get { return _a.Value; }
        }

        static void Main()
        {
            Console.WriteLine(A);
            Console.WriteLine(A);
            Console.WriteLine(A);

            Console.WriteLine(_a.Value);
            Console.WriteLine(_a.Value);
            Console.WriteLine(_a.Value);
        }
    }
}
