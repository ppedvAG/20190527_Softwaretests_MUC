using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hardware.Tests
{
    [TestClass]
    public class HardwareTest
    {
        [TestMethod]
        public void Can_GenerateSomeWork()
        {
            var generator = new TodoItemGenerator3000();

            var result = generator.GenerateSomeWork();
            result.Should().NotBeNull();
        }
    }
}
