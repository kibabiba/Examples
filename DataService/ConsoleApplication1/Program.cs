using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = new TestDataService.Duris4eEntities(new Uri("http://develop.kibabiba.ru/Duris4eDataService.svc"));

            foreach (var row in dt.holidays.Where(p=>p.desc.StartsWith("welcome")))
            {
                Console.WriteLine(row.day_time + " " + row.desc);
            }
        }
    }
}
