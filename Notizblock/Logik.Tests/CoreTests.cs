using System;
using System.Linq;
using AutoFixture;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logik.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void WorkOnTodoItems_returns_all_uncompleted_items_as_completed()
        {
            var fixture = new Fixture();
            var workload = fixture.CreateMany<TodoItem>(1000).ToList();
            var core = new Core(null); // Service wird hier nicht verwendet !
            int formerUncompletedItems = workload.Count(x => x.Completed == false);

            Assert.IsTrue(workload.Any(x => x.Completed == false));

            var result = core.WorkOnTodoItems(workload);

            Assert.AreEqual(formerUncompletedItems, result.Count); // Alle ehemalig completed Items müssen bearbeitet werden
            Assert.IsTrue(workload.All(x => x.Completed));           // Alle 1000 elemente sind nun completed
            Assert.IsTrue(result.All(x => x.Completed));           // Jedes einzelne ehem. uncompleted muss completed sein !
        }

        [TestMethod]
        public void WorkOnTodoItems_returns_all_uncompleted_items_as_completed_fluent()
        {
            var fixture = new Fixture();
            var workload = fixture.CreateMany<TodoItem>(1000).ToList();
            var core = new Core(null); // Service wird hier nicht verwendet !
            int numberOfFormerUncompletedItems = workload.Count(x => x.Completed == false);

            workload.Should().Contain(item => item.Completed == false);


            var result = core.WorkOnTodoItems(workload);

            result.Should().NotBeEmpty()
                           .And.HaveCount(numberOfFormerUncompletedItems)
                           .And.OnlyContain(items => items.Completed);

            workload.Should().OnlyContain(item => item.Completed);
        }

        [TestMethod]
        public void Generate10TodoItems_returns_10_items()
        {
            var mock = new Mock<IDevice>();
            mock.Setup(x => x.GenerateSomeWork())
                .Returns(new TodoItem());

            var core = new Core(null, mock.Object);

            var result = core.Generate10TodoItems();

            result.Should().HaveCount(10);
            mock.Verify(x => x.GenerateSomeWork(), Times.Exactly(10));
            // Nachkontrollieren, ob INTERN in meinem Core die methode "GenerateSomeWork" irgendwo aufgerufen wurde
        }

        [TestMethod]
        public void Generate100TodoItems_returns_100_items()
        {
            var mock = new Mock<IDevice>();
            mock.Setup(x => x.GenerateSomeWork())
                .Returns(new TodoItem());

            var core = new Core(null, mock.Object);

            var result = core.GenerateTodoItems(100);

            result.Should().HaveCount(100);
            mock.Verify(x => x.GenerateSomeWork(), Times.Exactly(100));
            // Nachkontrollieren, ob INTERN in meinem Core die methode "GenerateSomeWork" irgendwo aufgerufen wurde
        }

        [TestMethod]
        public void GenerateTodoItems_with_negative_amount_throws_ArgumentException()
        {
            var mock = new Mock<IDevice>();
            mock.Setup(x => x.GenerateSomeWork())
                .Returns(new TodoItem());

            var core = new Core(null, mock.Object);

            Assert.ThrowsException<ArgumentException>(() => core.GenerateTodoItems(-100));

            mock.Verify(x => x.GenerateSomeWork(), Times.Never());
            // Nachkontrollieren, ob INTERN in meinem Core die methode "GenerateSomeWork" irgendwo aufgerufen wurde
        }
    }
}
