using System;
using ConsoleApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTestProject
{
    [TestClass]
    public class TestExample
    {
        [TestMethod]
        public void TestMethod1()
        {
            var itrader = new Mock<Program.ITrader>();
            itrader.Setup(p => p.Name).Returns("huemock");


            var trader = new Program.MataTraderLibrary(itrader.Object);

            Assert.AreEqual("huemock", trader.GetName());

        }
    }
}
