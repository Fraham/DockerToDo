using System;

namespace Data.Models.Controller.TodoItem
{
    public class TodoItemStatusHistory
    {
        public TodoItemStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemStatusHistory history &&
                   Status == history.Status &&
                   CreatedDate == history.CreatedDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, CreatedDate);
        }
    }
}
