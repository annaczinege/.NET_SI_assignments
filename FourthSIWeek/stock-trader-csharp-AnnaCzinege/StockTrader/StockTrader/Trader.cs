namespace stockTrader
{
    public class Trader
    {
        private static Trader _instance;

        public static Trader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Trader();
                }
                return _instance;
            }
        }

        private readonly StockAPIService _stockApiService;

        public Trader()
        {
            _stockApiService = new StockAPIService();
        }
        
        /// <summary>
        /// Checks the price of a stock, and buys it if the price is not greater than the bid amount.
        /// </summary>
        /// <param name="symbol">the symbol to buy, e.g. aapl</param>
        /// <param name="bid">the bid amount</param>
        /// <returns>whether any stock was bought</returns>
        public bool Buy(string symbol, double bid) 
        {
            double price = _stockApiService.GetPrice(symbol);
            bool result;
            if (price <= bid) {
                result = true;
                _stockApiService.Buy(symbol);
                Logger.Instance.Log("Purchased " + symbol + " stock at $" + bid + ", since its higher that the current price ($" + price + ")");
            }
            else {
                Logger.Instance.Log("Bid for " + symbol + " was $" + bid + " but the stock price is $" + price + ", no purchase was made.");
                result = false;
            }
            return result;
    }
        
    }
}