using System;
using Moq;

namespace ConsoleApplication4
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Program
    {
        static void Main()
        {
            var iTrader = new Mock<ITrader>();
            iTrader.Setup(p => p.Name).Returns("HuyTrader");
            var trader = new MetaTraderLibrary(iTrader.Object);
            Console.WriteLine(trader.GetName());

            Console.ReadKey();
        }

        public class MetaTraderLibrary
        {
            private readonly ITrader _trader;

            public MetaTraderLibrary(ITrader trader)
            {
                _trader = trader;
            }

            public string GetName()
            {
                return _trader.Name;
            }
        }

        public interface ITrader
        {
            string Name { get; }
        }

        public class Mt4Trader : ITrader
        {           
            public string Name => throw new NotImplementedException();
        }

        public class Mt5Trader : ITrader
        {
            public string Name => throw new NotImplementedException();
        }
    }
}
