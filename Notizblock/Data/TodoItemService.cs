using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    // Liefert Daten 
    public class TodoItemService : ITodoItemService
    {
        public List<TodoItem> GetAllTodoItems()
        {
            // 1) Daten herunterladen
            // 2) JSON-String deserialisieren

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos").Result; // Ruft eine asynchrone Methode synchron auf
                return JsonConvert.DeserializeObject<List<TodoItem>>(json);
            }
        }

        public List<TodoItem> GetAllCompletedTodoItems()
        {
            var allItems = GetAllTodoItems();
            return allItems.Where(x => x.Completed == true).ToList();
        }
    }
}
