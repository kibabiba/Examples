using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main()
        {
            var time = new Stopwatch();
            time.Start();

            Console.WriteLine(time.Elapsed);
            GetDataAsync().Result.ToList().ForEach(Console.WriteLine);
            Console.WriteLine(time.Elapsed);
            Console.ReadKey();
        }

        private static async Task<IEnumerable<int>> GetDataAsync()
        {
            var p1 = GetAllLoginsAsinc();
            var p2 = GetFraudLoginAsinc();

            return (await p1).Intersect(await p2);
        }

        private static Task<int[]> GetAllLoginsAsinc()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return new[] { 1005, 105980 };
            });
        }

        private static Task<int[]> GetFraudLoginAsinc()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return new []{ 105980 };
            });
        }
    }
}
