using Microsoft.Extensions.Logging;
using Data.Models.DataAccess;
using MongoDB.Driver;
using Data.Services.DataAccess.Interfaces;
using System.Collections.Generic;

namespace Data.Services.DataAccess
{
    public class TodoItemService : BaseDataAccessService, ITodoItemService
    {
        private readonly IMongoCollection<TodoItemDataAccess> _items;
        
        public TodoItemService(ILogger<TodoItemService> logger) : base(logger)
        {
            _items = _database.GetCollection<TodoItemDataAccess>("TodoItem");
        }

        public TodoItemDataAccess Create(TodoItemDataAccess item)
        {
            _items.InsertOne(item);

            return item;
        }

        public TodoItemDataAccess Retrieve(string id)
        {
            return _items.Find<TodoItemDataAccess>(item => item.Id == id).FirstOrDefault();
        }

        public void Update(string id, TodoItemDataAccess updatedItem)
        {
            _items.ReplaceOne(item => item.Id == id, updatedItem);
        }

        public void Delete(string id)
        {
            _items.DeleteOne(item => item.Id == id);
        }

        public IEnumerable<TodoItemDataAccess> Retrieve()
        {
            return _items.Find<TodoItemDataAccess>(item => true).ToEnumerable();
        }
    }
}