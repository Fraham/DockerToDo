namespace Data.Models.Controller.TodoItem
{
    public class TodoItemUpdate
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus? Status { get; set; }
    }
}