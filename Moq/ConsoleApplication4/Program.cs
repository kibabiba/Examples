using System;
using Moq;

namespace ConsoleApplication4
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        static void Main()
        {
            {
                var trader = new MataTraderLibrary(Factory.GetTrader());
                Console.WriteLine(trader.GetName());
            }
            {
                var itrader = new Mock<ITrader>();
                itrader.Setup(p => p.Name).Returns("HuyTrader");
                var trader = new MataTraderLibrary(itrader.Object);
                Console.WriteLine(trader.GetName());
            }

            Console.ReadKey();
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

        private static class Factory
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

        // ReSharper disable once UnusedMember.Global
        public class MetaTrader : ITrader
        {           
            public string Name
            {
                get
                {
                    throw new NotImplementedException();
                } 
            }
        }

        private class HuyTrader : ITrader
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
