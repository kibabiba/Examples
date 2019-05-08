using ConsoleApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTestProject
{
    [TestClass]
    public class TestExample
    {
        [TestMethod]
        public void GetNameTest()
        {
            var iTrader = new Mock<Program.ITrader>();
            iTrader.Setup(p => p.Name).Returns("huemock");
            var trader = new Program.MetaTraderLibrary(iTrader.Object);
            Assert.AreEqual("huemock", trader.GetName());
        }
    }
}
