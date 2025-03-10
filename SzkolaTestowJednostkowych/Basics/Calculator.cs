
using System;

namespace SzkolaTestowJednostkowych.Basics
{
    public class Calculator
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Subtraction(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();

            return dividend / divisor;
        }

    }
}
