using System;
using System.Collections.Generic;
using Domain;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
    [TestClass]
    public class TodoItemServiceTests
    {
        // Assert auf Shim/Stub: Damit haben wir quasi getestet, dass das Fakes-Framework funktioniert
        [TestMethod]
        public void GetAllTodoItems_Fakes_returns_5_TodoItems()
        {
            var service = new TodoItemService();

            using (ShimsContext.Create())
            {
                Data.Fakes.ShimTodoItemService.AllInstances.GetAllTodoItems =
                    x => new List<TodoItem>
                    {
                        new TodoItem{Id=1,Title="Eins",UserId=1,Completed=false},
                        new TodoItem{Id=2,Title="Zwei",UserId=1,Completed=true},
                        new TodoItem{Id=3,Title="Drei",UserId=2,Completed=false},
                        new TodoItem{Id=4,Title="Vier",UserId=2,Completed=true},
                        new TodoItem{Id=5,Title="Fünf",UserId=2,Completed=false},
                    };

                var result = service.GetAllTodoItems(); // Dieser Test wird IMMER grün sein, da wir genau das Testen, was wir oben konfiguriert haben => False Positive

                Assert.AreEqual(5, result.Count);
            }
        }

        [TestMethod]
        public void GetAllCompletedTodoItems_returns_2()
        {
            var service = new TodoItemService();

            using (ShimsContext.Create())
            {
                Data.Fakes.ShimTodoItemService.AllInstances.GetAllTodoItems =
                    x => new List<TodoItem>
                    {
                        new TodoItem{Id=1,Title="Eins",UserId=1,Completed=false},
                        new TodoItem{Id=2,Title="Zwei",UserId=1,Completed=true},
                        new TodoItem{Id=3,Title="Drei",UserId=2,Completed=false},
                        new TodoItem{Id=4,Title="Vier",UserId=2,Completed=true},
                        new TodoItem{Id=5,Title="Fünf",UserId=2,Completed=false},
                    };

                var result = service.GetAllCompletedTodoItems(); // Ruft intern GetAllTodoItems auf
                // Hiermit teste ich NUR die Filter-Logik => Unit-Test

                Assert.AreEqual(2, result.Count);
            }
        }
    }
}
