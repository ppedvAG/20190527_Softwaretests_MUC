using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
    [TestClass]
    public class TodoItemServiceTests
    {
        [TestMethod]
        public void GetAllTodoItems_returns_5_TodoItems()
        {
            var service = new TodoItemService();

            var result = service.GetAllTodoItems();

            Assert.AreEqual(5, result.Count);
        }
    }
}
