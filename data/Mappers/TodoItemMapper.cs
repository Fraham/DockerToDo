using System.Collections.Generic;
using Data.Models.Controller.TodoItem;
using Data.Models.DataAccess;
using System.Linq;

namespace Data.Mappers
{
    public static class TodoItemMapper
    {
        public static IEnumerable<TodoItemRetrieve> ToController(IEnumerable<TodoItemDataAccess> todoItemInput)
        {
            return todoItemInput.Where(item => item != null).Select(ToController);
        }

        public static TodoItemRetrieve ToController(TodoItemDataAccess todoItemInput)
        {
            return new TodoItemRetrieve{
                Id = todoItemInput.Id,
                Title = todoItemInput.Title,
                Description = todoItemInput.Description,
                Status = todoItemInput.Status,
                CreatedDate = todoItemInput.CreatedDate,
                LastUpdatedDate = todoItemInput.LastUpdatedDate,
                StatusHistory = null //todo
            };
        }
    }
}