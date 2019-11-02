namespace Data.Models.DataAccess
{
    public class TodoItemStatusHistoryDataAccess : BaseModel
    {
        public string TodoItemId { get; set; }

        public TodoItemStatus Status { get; set; }
    }
}