using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calc = new Calculator();

            var erg = calc.Sum(3, 5);

            Assert.AreEqual(8, erg);
        }
    }
}
