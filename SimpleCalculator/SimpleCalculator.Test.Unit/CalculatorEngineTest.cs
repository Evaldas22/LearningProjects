using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorengine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValindResultForNonSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;

            double result = _calculatorengine.Calculate(number1, number2, "add");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValindResultForSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;

            double result = _calculatorengine.Calculate(number1, number2, "+");
            Assert.AreEqual(result, 3);
        }
    }
}
