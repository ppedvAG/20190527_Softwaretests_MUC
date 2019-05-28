using System.Collections.Generic;

namespace Domain
{
    public interface ITodoItemService
    {
        List<TodoItem> GetAllCompletedTodoItems();
        List<TodoItem> GetAllTodoItems();
    }
}