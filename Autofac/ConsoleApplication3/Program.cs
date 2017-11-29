using System.Linq;
using Autofac;
using System.Collections.Generic;

namespace DemoApp
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IWriter>();
            builder.RegisterType<HuyWriter>().As<IWriter>();
            Container = builder.Build();
            WriteDate();
        }

        public static void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writers = scope.Resolve<IEnumerable<IWriter>>();
                writers.Single(p => p is HuyWriter).WriteDate(); //switch HuyWriter and TodayWriter
            }
        }
    }
}
