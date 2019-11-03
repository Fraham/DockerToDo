using System;

namespace Data.Models.DataAccess
{
    public class TodoItemDataAccess : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemDataAccess access &&
                   base.Equals(obj) &&
                   Title == access.Title &&
                   Description == access.Description &&
                   Status == access.Status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Title, Description, Status);
        }
    }
}