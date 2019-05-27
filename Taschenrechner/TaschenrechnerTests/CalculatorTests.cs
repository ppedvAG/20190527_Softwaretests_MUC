using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Sum_3_and_5_returns_8()
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var erg = calc.Sum(3, 5);
            // Assert
            Assert.AreEqual(8, erg);
        }
    }
}
