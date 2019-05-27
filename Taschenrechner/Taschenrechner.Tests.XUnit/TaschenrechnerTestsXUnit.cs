using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Taschenrechner.Tests.XUnit
{
    public class TaschenrechnerTestsXUnit
    {
        [Fact]
        [Trait("XUnit",null)]
        public void Sum_3_and_5_returns_8()
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var erg = calc.Sum(3, 5);
            // Assert
            Assert.Equal(8, erg);
        }

        // Extremfall: null/0
        // Extremfall: Maximum / Minimum

        [Fact]
        [Trait("XUnit",null)]
        public void Sum_0_and_0_returns_0()
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var erg = calc.Sum(0, 0);
            // Assert
            Assert.Equal(0, erg);
        }

        [Fact]
        [Trait("XUnit",null)]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.Throws<OverflowException>(() => calc.Sum(Int32.MaxValue, 1));
        }

        [Fact]
        [Trait("XUnit",null)]
        public void Sum_MIN_and_N1_throws_OverflowException()
        {
            // Arrange
            var calc = new Calculator();
            // Act + Assert
            Assert.Throws<OverflowException>(() => calc.Sum(Int32.MinValue, -1));
        }

        [Theory]
        [Trait("XUnit",null)]
        [InlineData(3, 5, 8)]
        [InlineData(-1, -2, -3)]
        [InlineData(1000, 2000, 3000)]
        public void Can_Sum(int a, int b, int expected)
        {
            Calculator calc = new Calculator();
            var result = calc.Sum(a, b);
            Assert.Equal(expected, result);
        }
    }
}
