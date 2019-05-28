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
    }
}
