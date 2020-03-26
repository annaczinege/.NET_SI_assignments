using System;
using NUnit.Framework;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        
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