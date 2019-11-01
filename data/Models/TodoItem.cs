namespace Data.Models
{
    public class TodoItem : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus Status { get; set; }
    }
}