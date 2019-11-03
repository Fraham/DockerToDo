using System;

namespace Data.Models.DataAccess
{
    public class TodoItemStatusHistoryDataAccess : BaseModel
    {
        public string TodoItemId { get; set; }

        public TodoItemStatus Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TodoItemStatusHistoryDataAccess access &&
                   base.Equals(obj) &&
                   TodoItemId == access.TodoItemId &&
                   Status == access.Status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TodoItemId, Status);
        }
    }
}