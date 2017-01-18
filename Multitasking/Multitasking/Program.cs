using System;
using System.Threading;
using System.Threading.Tasks;

namespace Multitasking
{
    class Program
    {
        static void Main()
        {    
            Console.WriteLine(DateTime.Now);

            Task.WaitAll(Task.Run(() =>
            {
                Console.WriteLine("huy");
                Thread.Sleep(5000);
            }), Task.Run(() =>
            {
                Console.WriteLine("pizda");
                Thread.Sleep(5000);
            }).ContinueWith(continualtion => Console.WriteLine("Djigurda")));

            Console.WriteLine(DateTime.Now);           
            Console.ReadKey();            
        }
    }
}
