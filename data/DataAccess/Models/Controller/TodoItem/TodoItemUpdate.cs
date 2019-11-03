using System;
using System.Collections.Generic;

namespace Data.Models.Controller.TodoItem
{
    public class TodoItemUpdate
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus? Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemUpdate update &&
                   Title == update.Title &&
                   Description == update.Description &&
                   EqualityComparer<TodoItemStatus?>.Default.Equals(Status, update.Status);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, Status);
        }
    }
}