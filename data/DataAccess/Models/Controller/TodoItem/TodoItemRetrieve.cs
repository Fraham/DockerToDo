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
    }
}