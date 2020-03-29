using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockTrader
{
    public interface IStockAPIService
    {
        double GetPrice(string symbol);
        bool Buy(string symbol);
    }
}
