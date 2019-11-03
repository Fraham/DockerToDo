using System;

namespace Data.Models.Controller.TodoItem
{
    public class TodoItemCreate
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemCreate create &&
                   Title == create.Title &&
                   Description == create.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description);
        }
    }
}