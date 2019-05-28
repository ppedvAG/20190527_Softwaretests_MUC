using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logik
{
    public class Core
    {
        public Core(ITodoItemService service) // Dependency-Injection
        {
            this.service = service;
        }
        public Core(ITodoItemService service, IDevice device) // Dependency-Injection
        {
            this.service = service;
            this.device = device;
        }

        private readonly IDevice device;
        private readonly ITodoItemService service;

        // Wir bekommen Items rein und arbeiten alle Items, die nicht "completed" sind ab
        // Alle Items die auf "completed" gestellt werden, werden als Ergebnis zurückgegeben
        public List<TodoItem> WorkOnTodoItems(List<TodoItem> workload)
        {
            List<TodoItem> finishedItems = new List<TodoItem>();
            foreach (var item in workload)
            {
                if(item.Completed == false)
                {
                    item.Completed = true;
                    finishedItems.Add(item);
                }
            }
            return finishedItems;
        }

        public List<TodoItem> Generate10TodoItems()
        {
            List<TodoItem> result = new List<TodoItem>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(device.GenerateSomeWork());
            }
            return result;
        }

        public List<TodoItem> GenerateTodoItems(int amount)
        {
            if (amount < 0)
                throw new ArgumentException();

            List<TodoItem> result = new List<TodoItem>();
            // device.GenerateSomeWork(); // bug, ich steuer es an aber es pasiert nix

            for (int i = 0; i < amount; i++)
            {
                result.Add(device.GenerateSomeWork());
            }

            return result;
        }
    }
}
