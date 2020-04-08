using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ReflecionSample
{
    public class Calculator
    {
        public virtual int AddNumb(int numb1, int numb2)
        {
            return numb1 + numb2;
        }
    }
}
