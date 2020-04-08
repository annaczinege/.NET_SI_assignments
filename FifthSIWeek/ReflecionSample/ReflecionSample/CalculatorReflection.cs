using System;
using System.Collections.Generic;
using System.Text;

namespace ReflecionSample
{
    class CalculatorReflection
    {
        int answer;
        public CalculatorReflection()
        {
            answer = 0;
        }

        public int AddNumb(int numb1, int numb2)
        {
            answer = numb1 + numb2;
            return answer;
        }
    }
}
