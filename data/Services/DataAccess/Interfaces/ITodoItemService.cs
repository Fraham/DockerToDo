using System.Collections.Generic;
using Data.Models.DataAccess;

namespace Data.Services.DataAccess.Interfaces
{
    public interface ITodoItemService
    {
        TodoItemDataAccess Create(TodoItemDataAccess item);

        TodoItemDataAccess Retrieve(string id);

        IEnumerable<TodoItemDataAccess> Retrieve();

        void Update(string id, TodoItemDataAccess updatedItem);

        void Delete(string id);
    }
}