using System.Collections.Generic;
using Data.Models.Controller.TodoItem;
using Data.Models.DataAccess;
using System.Linq;

namespace Data.Mappers
{
    public static class TodoItemMapper
    {
        public static IEnumerable<TodoItemRetrieve> ToController(IEnumerable<TodoItemDataAccess> todoItemInput, Dictionary<string, List<TodoItemStatusHistoryDataAccess>> history)
        {
            return todoItemInput.Where(item => item != null).Select(x => ToController(x, history[x.Id]));
        }

        public static TodoItemRetrieve ToController(TodoItemDataAccess todoItemInput, List<TodoItemStatusHistoryDataAccess> history)
        {
            return new TodoItemRetrieve
            {
                Id = todoItemInput.Id,
                Title = todoItemInput.Title,
                Description = todoItemInput.Description,
                Status = todoItemInput.Status,
                CreatedDate = todoItemInput.CreatedDate,
                LastUpdatedDate = todoItemInput.LastUpdatedDate,
                StatusHistory = ToController(history)
            };
        }

        public static IList<TodoItemStatusHistory> ToController(List<TodoItemStatusHistoryDataAccess> history){
            return history.Where(item => item != null).Select(ToController).ToList();
        }

        public static TodoItemStatusHistory ToController(TodoItemStatusHistoryDataAccess history)
        {
            return new TodoItemStatusHistory{
                DateCreated = history.CreatedDate,
                Status = history.Status
            };
        }
    }
}