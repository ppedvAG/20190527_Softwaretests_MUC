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

        // Extremfall: null/0
        // Extremfall: Maximum / Minimum

        [TestMethod]
        public void Sum_0_and_0_returns_0()
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var erg = calc.Sum(0, 0);
            // Assert
            Assert.AreEqual(0, erg);
        }

        [TestMethod]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.ThrowsException<OverflowException>(() => calc.Sum(Int32.MaxValue, 1));
        }

        [TestMethod]
        public void Sum_MIN_and_N1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.ThrowsException<OverflowException>(() => calc.Sum(Int32.MinValue, -1));
        }

    }
}
