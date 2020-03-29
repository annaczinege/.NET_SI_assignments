using NUnit.Framework;
using NSubstitute;
using System;

namespace stockTrader
{
    public class StockAPIServiceTest
    {
        private IStockAPIService _stockAPIService;
        private IRemoteURLReader _remoteURLReader;
        private string _symbol;
        private double _expectedPrice;
        private string _apiPath;

        [SetUp]
        public void Setup()
        {
            _remoteURLReader = Substitute.For<IRemoteURLReader>();
            _apiPath = "https://financialmodelingprep.com/api/v3/stock/real-time-price/{0}";
        }

        [Test] // everything works
        public void TestGetPriceNormalValues()
        {
            //Arrange
            _symbol = "aapl";
            _expectedPrice = 247.74;

            //Act
            _remoteURLReader.ReadFromUrl(String.Format(_apiPath, _symbol)).Returns("{\n  \"symbol\" : \"AAPL\",\n  \"price\" : 247.74\n}");
            _stockAPIService = new StockAPIService(_remoteURLReader);
            double actualPrice = _stockAPIService.GetPrice(_symbol);

            //Assert
            Assert.AreEqual(_expectedPrice, actualPrice);
        }

        [Test] // readFromURL threw an exception
        public void TestGetPriceServerDown()
        {
            //Arrange
            _symbol = "duck";
            _expectedPrice = 247.74;

            //Act
            _remoteURLReader.ReadFromUrl(String.Format(_apiPath, _symbol)).Returns(x => throw new NullReferenceException());
            _stockAPIService = new StockAPIService(_remoteURLReader);

            //Assert
            Assert.Throws<NullReferenceException>(() => _stockAPIService.GetPrice(_symbol));
        }

        [Test] // readFromURL returned wrong JSON
        public void TestGetPriceMalformedResponse() 
        {
            //Arrange
            _symbol = "aapl";
            _expectedPrice = 247.74;

            //Act
            _remoteURLReader.ReadFromUrl(String.Format(_apiPath, _symbol)).Returns("{\n  \"symbol\" : \"CHY\",\n  \"price\" : 8.41\n}");
            _stockAPIService = new StockAPIService(_remoteURLReader);

            //Assert
            Assert.AreNotEqual(_expectedPrice, _stockAPIService.GetPrice(_symbol));
        }
    }
}