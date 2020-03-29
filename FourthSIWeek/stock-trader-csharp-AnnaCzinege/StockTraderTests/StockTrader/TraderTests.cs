using NUnit.Framework;
using NSubstitute;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        private ITrader _trader;
        private string _symbol;
        
        [SetUp]
        public void Setup()
        {
            _symbol = "aapl";
            var stockAPIService = Substitute.For<IStockAPIService>();
            stockAPIService.GetPrice(_symbol).Returns(247.74);
            var logger = Substitute.For<ILogger>();
            _trader = new Trader(stockAPIService, logger);
        }

        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
            //Arrange
            double bid = 100;
            //Act
            bool isBidHigherThanPrice = _trader.Buy(_symbol, bid);
            //Assert
            Assert.IsFalse(isBidHigherThanPrice);
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
            //Arrange
            double bid = 300;
            //Act
            bool isBidHigherThanPrice = _trader.Buy(_symbol, bid);
            //Assert
            Assert.IsTrue(isBidHigherThanPrice);
        }

        [TearDown]
        public void TearDown()
        {
            _symbol = "";
            _trader = null;
        }
    }
}