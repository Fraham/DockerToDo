using System;
using System.Collections.Generic;

namespace Data.Models.Controller.TodoItem
{
    public class TodoItemRetrieve
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus Status { get; set; }

        public IList<TodoItemStatusHistory> StatusHistory { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemRetrieve retrieve &&
                   Id == retrieve.Id &&
                   Title == retrieve.Title &&
                   Description == retrieve.Description &&
                   Status == retrieve.Status &&
                   EqualityComparer<IList<TodoItemStatusHistory>>.Default.Equals(StatusHistory, retrieve.StatusHistory) &&
                   CreatedDate == retrieve.CreatedDate &&
                   LastUpdatedDate == retrieve.LastUpdatedDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Description, Status, StatusHistory, CreatedDate, LastUpdatedDate);
        }
    }
}