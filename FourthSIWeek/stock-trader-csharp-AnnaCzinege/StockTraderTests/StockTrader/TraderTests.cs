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
        }

        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
        }
    }
}