using System.Collections.Generic;
using Data.Models.DataAccess;

namespace Data.Services.DataAccess.Interfaces
{
    public interface ITodoItemStatusHistoryService
    {
        TodoItemStatusHistoryDataAccess Create(TodoItemStatusHistoryDataAccess item);

        TodoItemStatusHistoryDataAccess Retrieve(string id);

        IEnumerable<TodoItemStatusHistoryDataAccess> RetrieveByTodoItemId(string todoItemId);

        IEnumerable<TodoItemStatusHistoryDataAccess> Retrieve();

        void Delete(string id);
    }
}