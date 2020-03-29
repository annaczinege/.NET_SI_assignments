using System;

namespace stockTrader
{

    internal class TradingApp
    {
        private StockAPIService _stockAPIService;
        public static void Main(string[] args)
        {
            
            TradingApp app = new TradingApp();
            app.Start(trader);
        }

        public TradingApp(StockAPIService stockAPIService)
        {
            _stockAPIService = stockAPIService;
            Logger logger = new Logger();
            Trader trader = new Trader(stockAPIService, logger);
        }

        public void Start(Trader trader)
        {
            Console.WriteLine("Enter a stock symbol (for example aapl):");
            string symbol = Console.ReadLine();
            Console.WriteLine("Enter the maximum price you are willing to pay: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please enter a number.");
            }

            try
            {
                bool purchased = trader.Buy(symbol, price);
                if (purchased)
                {
                    trader. logger.Log("Purchased stock!");
                }
                else
                {
                    Logger.Instance.Log("Couldn't buy the stock at that price.");
                }
            }
            catch (Exception e)
            {
                Logger.Instance.Log("There was an error while attempting to buy the stock: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}