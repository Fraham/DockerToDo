using System;
using Data.Models;
using Data.Models.Controller.TodoItem;
using Data.Models.DataAccess;

namespace DataAccess.Helpers
{
    public static class ObjectMaker
    {
        public static class Defaults
        {
            public static class TodoItems
            {
                public const string Title = "Default Title";
                public const string Description = "Default Description";

                public const TodoItemStatus Status = TodoItemStatus.Pending;
                public static DateTime CreatedDate = DateTime.Parse("2019-10-01 08:07:06");
                public static DateTime LastUpdatedDate = DateTime.Parse("2019-10-01 08:07:06");

                public static string[] Titles = { "Title 1", "Title with null description", "Title with empty description", "Title with white space description" };

                public static string[] Descriptions = { "Description 1", null, "", "    " };

                public static TodoItemStatus[] Statues = { TodoItemStatus.Pending, TodoItemStatus.Pending, TodoItemStatus.Pending, TodoItemStatus.Pending };

                public static DateTime[] CreatedDates = { DateTime.Parse("2019-10-01 08:07:06"), DateTime.Parse("2019-10-02 08:07:06"), DateTime.Parse("2019-10-03 08:07:06"), DateTime.Parse("2019-10-04 08:07:06") };

                public static DateTime[] LastUpdatedDates = { DateTime.Parse("2019-10-01 08:07:06"), DateTime.Parse("2019-10-02 08:07:06"), DateTime.Parse("2019-10-03 08:07:06"), DateTime.Parse("2019-10-04 08:07:06") };
            }
        }
        public static TodoItemCreate GetTodoItemCreate(string title = Defaults.TodoItems.Title, string description = Defaults.TodoItems.Description)
        {
            return new TodoItemCreate
            {
                Title = title,
                Description = description
            };
        }

        public static TodoItemCreate GetTodoItemCreate(int index)
        {
            return new TodoItemCreate
            {
                Title = Defaults.TodoItems.Titles[index],
                Description = Defaults.TodoItems.Descriptions[index]
            };
        }

        public static TodoItemDataAccess GetTodoItemDataAccess(string title = Defaults.TodoItems.Title, string description = Defaults.TodoItems.Description, TodoItemStatus status = Defaults.TodoItems.Status, DateTime? createdDate = null, DateTime? lastUpdatedDate = null)
        {
            return new TodoItemDataAccess
            {
                Title = title,
                Description = description,
                Status = status,
                CreatedDate = createdDate ?? Defaults.TodoItems.CreatedDate,
                LastUpdatedDate = lastUpdatedDate ?? Defaults.TodoItems.LastUpdatedDate
            };
        }

        public static TodoItemDataAccess GetTodoItemDataAccess(int index)
        {
            return new TodoItemDataAccess
            {
                Title = Defaults.TodoItems.Titles[index],
                Description = Defaults.TodoItems.Descriptions[index],
                Status = Defaults.TodoItems.Statues[index],
                CreatedDate = Defaults.TodoItems.CreatedDates[index],
                LastUpdatedDate = Defaults.TodoItems.LastUpdatedDates[index]
            };
        }
    }
}