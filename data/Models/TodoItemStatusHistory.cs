namespace Data.Models
{
    public class TodoItemStatusHistory : BaseModel
    {
        public string TodoItemId { get; set; }

        public TodoItemStatus Status { get; set; }
    }
}