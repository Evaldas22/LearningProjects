using System;
namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate(double a, double b, string operation)
        {
            double result;
            switch (operation.ToLower())
            {
                case "add":
                case "+":
                    result = a + b;
                    break;
                case "subtract":
                case "-":
                    result = a - b;
                    break;
                case "multiply":
                case "*":
                    result = a * b;
                    break;
                case "divide":
                case "/":
                    result = a / b;
                    break;
                default:
                    throw new InvalidOperationException("Specified operation is not recognised.");
            }


            return result;
        }
    }
}
