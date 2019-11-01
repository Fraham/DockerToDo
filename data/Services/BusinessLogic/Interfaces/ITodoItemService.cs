using System.Collections.Generic;
using Data.Models.Controller.TodoItem;

namespace Data.Services.BusinessLogic.Interfaces
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItemRetrieve> GetAll();

        TodoItemRetrieve Create(TodoItemCreate item);
    }
}