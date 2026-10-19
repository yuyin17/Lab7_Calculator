using System;

namespace Calculator
{
    public class CalculatorBasic
    {
        private double currentValue = 0;

        public double CurrentValue => currentValue;

        public void Add(double value)
        {
            currentValue += value;
        }

        public void Subtract(double value)
        {
            currentValue -= value;
        }

        public void Multiply(double value)
        {
            currentValue *= value;
        }

        public void Divide(double value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            currentValue /= value;
        }

        public double SquareRoot(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input for square root.");
            }
            return Math.Sqrt(value);
        }

        public double Reciprocal(double value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return 1 / value;
        }

        public double ChangeSign(double value)
        {
            return -value;
        }

        public void Clear()
        {
            currentValue = 0;
        }
    }
}