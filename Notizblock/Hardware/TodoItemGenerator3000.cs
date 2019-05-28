using AutoFixture;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware
{
    public class TodoItemGenerator3000 : IDevice
    {
        public TodoItem GenerateSomeWork()
        {
            var fix = new Fixture();
            Console.Beep();
            return fix.Create<TodoItem>();
        }
    }
}
