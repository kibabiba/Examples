using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(DateTime.Now);
            foreach (var login in GetDataAsync().Result)
            {
                Console.WriteLine(login);
            }
            Console.WriteLine(DateTime.Now);
            Console.ReadKey();
        }

        public static async Task<IEnumerable<int>> GetDataAsync()
        {
            var p1 = GetAllLogins();
            var p2 = GetFraudLogin();

            return (await p1).Intersect(await p2);
        }

        public static async Task<int[]> GetAllLogins()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return new[] { 1005, 105980 };
            });
        }

        public static async Task<int[]> GetFraudLogin()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);
                return new []{ 105980 };
            });
        }
    }
}
