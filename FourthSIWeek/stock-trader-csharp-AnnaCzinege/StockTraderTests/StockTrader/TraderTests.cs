using NUnit.Framework;
using NSubstitute;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        private ITrader _trader;
        private readonly ILogger _logger = Substitute.For<ILogger>();
        private readonly IStockAPIService _stockAPI = Substitute.For<IStockAPIService>();
        
        [SetUp]
        public void Setup()
        {
            _trader = new Trader(_stockAPI, _logger);
        }

        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
            _trader.Buy("$", 100).Returns(false);
            Assert.That(_trader.Buy("$", 100), Is.EqualTo(false));
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
        }
    }
}