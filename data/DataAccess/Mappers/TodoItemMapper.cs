using System.Collections.Generic;
using Data.Models.Controller.TodoItem;
using Data.Models.DataAccess;
using System.Linq;
using System;
using Data.Models;

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
            if (todoItemInput == null)
            {
                return null;
            }

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

        public static IList<TodoItemStatusHistory> ToController(List<TodoItemStatusHistoryDataAccess> history)
        {
            if (history == null)
            {
                return new List<TodoItemStatusHistory>();
            }

            return history.Where(item => item != null).Select(ToController).ToList();
        }

        public static TodoItemStatusHistory ToController(TodoItemStatusHistoryDataAccess history)
        {
            if (history == null)
            {
                return null;
            }

            return new TodoItemStatusHistory
            {
                CreatedDate = history.CreatedDate,
                Status = history.Status
            };
        }

        public static TodoItemDataAccess ToDataAccess(TodoItemCreate create, DateTime createdDate, TodoItemStatus status = TodoItemStatus.Pending)
        {
            if (create == null)
            {
                return null;
            }

            return new TodoItemDataAccess
            {
                Title = create.Title,
                Description = create.Description,
                Status = status,
                CreatedDate = createdDate,
                LastUpdatedDate = createdDate
            };
        }
    }
}
