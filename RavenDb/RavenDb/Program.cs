using System;
using System.Linq;
using Raven.Client.Document;
using Raven.Client.Linq;

namespace RavenDb
{
    class Program
    {
        static void Main()
        {
            using (var documentStore = new DocumentStore { Url = "http://192.168.1.40/RavenDB/" }.Initialize())
            {
                using (var session = documentStore.OpenSession())
                {
                    var user = new User { Id = 1, Name = "Test"};
                    session.Store(user);                    
                    session.SaveChanges();

                    var all = session.Query<User>().Where(p => p.Name == "Test").ToList();
                    foreach (var company in all)
                    {
                        Console.WriteLine(company.Name);
                    }
                }
            }
            Console.ReadLine();
        }

        public class User
        {
            public int Id;
            public string Name;
        }
    }
}
