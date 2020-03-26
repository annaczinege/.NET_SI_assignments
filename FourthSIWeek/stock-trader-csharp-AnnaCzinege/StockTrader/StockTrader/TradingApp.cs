using System;

namespace stockTrader
{

  internal class TradingApp
  {
    public static void Main(string[] args)
    {
	    TradingApp app = new TradingApp();
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
	    
	    try {
		    bool purchased = Trader.Instance.Buy(symbol, price);
		    if (purchased) {
			    Logger.Instance.Log("Purchased stock!");
		    }
		    else {
			    Logger.Instance.Log("Couldn't buy the stock at that price.");
		    }
	    } catch (Exception e) {
		    Logger.Instance.Log("There was an error while attempting to buy the stock: " + e.Message);
	    }
        Console.ReadLine();
    }
  }
}