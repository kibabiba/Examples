using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            const string json = @"{
                  'channel': {
                    'title': 'James Newton-King',
                    'link': 'http://james.newtonking.com',
                    'description': 'James Newton-Kings blog.',
                    'item': [
                      {
                        'title': 'Json.NET 1.3 + New license + Now on CodePlex',
                        'description': 'Annoucing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                        'link': 'http://james.newtonking.com/projects/json-net.aspx',
                        'categories': [
                          'Json.NET',
                          'Json.NET',
                          'Json.NET',
                          'CodePlex'
                        ]
                      },
                      {
                        'title': 'LINQ to JSON beta',
                        'description': 'Annoucing LINQ to JSON',
                        'link': 'http://james.newtonking.com/projects/json-net.aspx',
                        'categories': [
                          'Json.NET',
                          'LINQ',
                          'LINQ',
                          'LINQ'
                        ]
                      }
                    ]
                  }
                }";

            (from c in JObject.Parse(json)["channel"]["item"].Children()["categories"].Values<string>()
             group c by c into g
             select new { Category = g.Key, Count = g.Count() }).Where(p => p.Count > 1).
            AsParallel().WithDegreeOfParallelism(2).ForAll(item => Console.WriteLine("{0} Count:{1}", item.Category, item.Count));
        }
    }
}
