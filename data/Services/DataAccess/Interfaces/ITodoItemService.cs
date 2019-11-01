using Data.Models.DataAccess;

namespace Data.Services.DataAccess.Interfaces
{
    public interface ITodoItemService
    {
        TodoItemDataAccess Create(TodoItemDataAccess item);

        TodoItemDataAccess Retreive(string id);

        void Update(string id, TodoItemDataAccess updatedItem);

        void Delete(string id);
    }
}