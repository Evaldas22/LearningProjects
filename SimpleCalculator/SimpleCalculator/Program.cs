using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //this will convert the input data to numeric
                InputConverter inputConverter = new InputConverter();

                //make an engine that calculates
                CalculatorEngine calculatorengine = new CalculatorEngine();

                Console.Write("Please enter first number: ");
                double firstNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.Write("Please enter second number: ");
                double secondNumber = inputConverter.ConvertInputToNumeric(Console.ReadLine());
                Console.Write("Please enter operation (+,-,*,/): ");
                string operation = Console.ReadLine();

                double result = calculatorengine.Calculate(firstNumber, secondNumber, operation);

                Console.WriteLine("The result is {0}", result);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // In real world we would want to log this message!!
                Console.WriteLine(ex.Message);
            }
        }
    }
}
