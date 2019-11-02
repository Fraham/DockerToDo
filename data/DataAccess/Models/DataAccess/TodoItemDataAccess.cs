namespace Data.Models.DataAccess
{
    public class TodoItemDataAccess : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TodoItemStatus Status { get; set; }
    }
}