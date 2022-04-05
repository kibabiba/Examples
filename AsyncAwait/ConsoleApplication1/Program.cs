using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine(DateTime.Now);
            foreach (var login in await GetDataAsync())
            {
                Console.WriteLine(login);
            }
            Console.WriteLine(DateTime.Now);
            Console.ReadKey();
        }

        private static async Task<IEnumerable<int>> GetDataAsync()
        {
            var allLogins =  GetAllLoginsAsync();
            var fraudLogin = GetFraudLoginAsync();

            return (await allLogins).Except(await fraudLogin);
        }

        private static Task<int[]> GetAllLoginsAsync()
        {
            return Task.Run(() =>
            {
                Task.Delay(new TimeSpan(0, 0, 5)).Wait();
                return new[] { 1005, 105980 };
            });
        }

        private static Task<int[]> GetFraudLoginAsync()
        {
            return Task.Run(() =>
            {
                Task.Delay(new TimeSpan(0, 0, 5)).Wait();
                return new[] { 105980 };
            });
        }
    }
}
