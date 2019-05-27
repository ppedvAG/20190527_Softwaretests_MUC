using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [TestCategory("MSTest")]
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
        [TestCategory("MSTest")]
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
        [TestCategory("MSTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.ThrowsException<OverflowException>(() => calc.Sum(Int32.MaxValue, 1));
        }

        [TestMethod]
        [TestCategory("MSTest")]
        public void Sum_MIN_and_N1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.ThrowsException<OverflowException>(() => calc.Sum(Int32.MinValue, -1));
        }

        [TestMethod]
        [TestCategory("MSTest")]
        [DataRow(3,5,8)]
        [DataRow(-1,-2,-3)]
        [DataRow(1000,2000,3000)]
        public void Can_Sum(int a, int b, int expected)
        {
            Calculator calc = new Calculator();
            var result = calc.Sum(a, b);
            Assert.AreEqual(expected, result);
        }

    }
}
