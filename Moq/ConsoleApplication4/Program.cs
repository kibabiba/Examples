using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection nvc = new NameValueCollection()
{
  {"key1", "value1"},
  {"key1", "value11"},
  {"key2", "value2"},
  {"key3", "value3"}
};

            nvc["key1"] = "huy";

            Console.WriteLine(nvc["key1"]);
        }


        public class MataTraderLibrary
        {
            private readonly ITrader _trader;

            public MataTraderLibrary(ITrader trader)
            {
                _trader = trader;
            }

            public string GetName()
            {
                return _trader.Name;
            }
        }

        public class Factory
        {
            public static ITrader GetTrader()
            {
               return new HuyTrader();
            }
        }

        public interface ITrader
        {
            string Name { get; }
        }

        public class MetaTrader : ITrader
        {           
            public string Name
            {
                get
                {
                    return "MetaTrader";
                } 
            }
        }

        public class HuyTrader : ITrader
        {
            public string Name
            {
                get
                {
                    return "HuyTrader";
                }
            }
        }
    }
}
