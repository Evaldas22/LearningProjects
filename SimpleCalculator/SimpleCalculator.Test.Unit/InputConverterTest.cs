using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new InputConverter();

        [TestMethod]
        public void ConvertValidStringInputIntoDouble()
        {
            string inputNubmer = "5";
            double convertedNumber = _inputConverter.ConvertInputToNumeric(inputNubmer);
            Assert.AreEqual(convertedNumber, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Expected a numeric value.")]
        public void FailsToConvertInvalidStringInputIntoDouble()
        {
            string inputNumber = "*";
            double convertedNumber = _inputConverter.ConvertInputToNumeric(inputNumber);
        }
    }
}
