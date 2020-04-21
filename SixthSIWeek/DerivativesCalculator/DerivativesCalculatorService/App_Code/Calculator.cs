using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativesCalculatorService.App_Code
{
    public class Calculator : IDerivativesCalculator
    {
        #region IDerivatesCalsulator Members
        public decimal CalculateDerivative(int days, string[] symbols, string[] functions)
        {
            return DateTime.Now.Millisecond;
        }
        #endregion
    }
}
