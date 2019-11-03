using System;

namespace Data.Models.Controller.TodoItem
{
    public class TodoItemStatusHistory
    {
        public TodoItemStatus Status { get; set; }

        public DateTime DateCreated { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemStatusHistory history &&
                   Status == history.Status &&
                   DateCreated == history.DateCreated;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, DateCreated);
        }
    }
}