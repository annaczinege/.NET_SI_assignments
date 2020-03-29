using System;

namespace stockTrader
{

	internal class TradingApp
	{
		private readonly ILogger _logger;
		private readonly ITrader _trader;

		public TradingApp(ITrader trader, ILogger logger)
		{
			_trader = trader;
			_logger = logger;
		}
		public static void Main(string[] args)
		{
			IRemoteURLReader remoteURLReader = new RemoteURLReader();
			IStockAPIService stockAPIService = new StockAPIService(remoteURLReader);
			ILogger logger = new Logger();
			ITrader trader = new Trader(stockAPIService, logger);
			TradingApp app = new TradingApp(trader, logger);
			app.Start();
		}

		public void Start()
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
				bool purchased = _trader.Buy(symbol, price);
				if (purchased)
				{
					_logger.Log("Purchased stock!");
				}
				else
				{
					_logger.Log("Couldn't buy the stock at that price.");
				}
			}
			catch (Exception e)
			{
				_logger.Log("There was an error while attempting to buy the stock: " + e.Message);
			}
			Console.ReadLine();
		}
	}
}