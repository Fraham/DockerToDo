using Microsoft.Extensions.Logging;
using Data.Models.DataAccess;
using MongoDB.Driver;
using Data.Services.DataAccess.Interfaces;
using System.Collections.Generic;

namespace Data.Services.DataAccess
{
    public class TodoItemStatusHistoryService : BaseDataAccessService, ITodoItemStatusHistoryService
    {
        private readonly IMongoCollection<TodoItemStatusHistoryDataAccess> _items;
        
        public TodoItemStatusHistoryService(ILogger<TodoItemStatusHistoryService> logger) : base(logger)
        {
            _items = _database.GetCollection<TodoItemStatusHistoryDataAccess>("TodoItemStatusHistory");
        }

        public TodoItemStatusHistoryDataAccess Create(TodoItemStatusHistoryDataAccess item)
        {
            _items.InsertOne(item);

            return item;
        }

        public void Delete(string id)
        {
            _items.DeleteOne(item => item.Id == id);
        }

        public TodoItemStatusHistoryDataAccess Retrieve(string id)
        {
            return _items.Find<TodoItemStatusHistoryDataAccess>(item => item.Id == id).FirstOrDefault();
        }

        public IEnumerable<TodoItemStatusHistoryDataAccess> RetrieveByTodoItemId(string todoItemId)
        {
            return _items.Find<TodoItemStatusHistoryDataAccess>(item => item.TodoItemId == todoItemId).ToEnumerable();
        }

        public IEnumerable<TodoItemStatusHistoryDataAccess> Retrieve()
        {
            return _items.Find<TodoItemStatusHistoryDataAccess>(item => true).ToEnumerable();
        }
    }
}