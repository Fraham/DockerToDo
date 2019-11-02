using System.Collections.Generic;
using Data.Mappers;
using Data.Models.Controller.TodoItem;
using Data.Services.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;
using DataAccessLayer = Data.Services.DataAccess.Interfaces;
using System.Linq;
using System;
using Data.Models.DataAccess;
using Data.Models;

namespace Data.Services.BusinessLogic
{
    public class TodoItemService : BaseService, ITodoItemService
    {
        private DataAccessLayer.ITodoItemService _todoItemService;
        private DataAccessLayer.ITodoItemStatusHistoryService _todoItemStatusHistoryService;

        public TodoItemService(ILogger<BaseService> logger, DataAccessLayer.ITodoItemService todoItemService, DataAccessLayer.ITodoItemStatusHistoryService todoItemStatusHistoryService) : base(logger)
        {
            _todoItemService = todoItemService;
            _todoItemStatusHistoryService = todoItemStatusHistoryService;
        }

        public IEnumerable<TodoItemRetrieve> GetAll()
        {
            var items = _todoItemService.Retrieve();
            var history = _todoItemStatusHistoryService.Retrieve().GroupBy(h => h.TodoItemId).ToDictionary(g => g.Key, g => g.ToList());

            return TodoItemMapper.ToController(items, history);
        }

        public TodoItemRetrieve Get(string id)
        {
            var item = _todoItemService.Retrieve(id);
            var history = _todoItemStatusHistoryService.RetrieveByTodoItemId(id).ToList();

            return TodoItemMapper.ToController(item, history);
        }

        public TodoItemRetrieve Create(TodoItemCreate item)
        {
            var now = DateTime.UtcNow;
            var status = TodoItemStatus.Pending;

            var objectToCreate = TodoItemMapper.ToDataAccess(item, now, status);

            var createdThing = _todoItemService.Create(objectToCreate);

            var history = MakeStatusHistory(createdThing.Id, status, now);

            return TodoItemMapper.ToController(createdThing, new List<TodoItemStatusHistoryDataAccess> { history });
        }

        public void Update(string id, TodoItemUpdate updatedItem)
        {
            var currentItem = _todoItemService.Retrieve(id);

            if (currentItem == null)
            {
                var message = $"Not able to retrieve todo item with Id: {id}";

                _logger.LogError(message);
                throw new Exception(message);
            }

            var statusChanged = updatedItem.Status.HasValue && updatedItem.Status.Value != currentItem.Status;

            var now = DateTime.UtcNow;

            var item = new TodoItemDataAccess
            {
                Id = currentItem.Id,
                Title = string.IsNullOrWhiteSpace(updatedItem.Title) ? currentItem.Title : updatedItem.Title,
                Description = updatedItem.Description == null ? currentItem.Description : updatedItem.Description,
                Status = !statusChanged ? currentItem.Status : updatedItem.Status.Value,
                CreatedDate = currentItem.CreatedDate,
                LastUpdatedDate = now
            };

            _todoItemService.Update(id, item);

            if (statusChanged)
            {
                MakeStatusHistory(id, updatedItem.Status.Value, now);
            }
        }

        private TodoItemStatusHistoryDataAccess MakeStatusHistory(string todoItemId, TodoItemStatus status, DateTime date)
        {
            return _todoItemStatusHistoryService.Create(new TodoItemStatusHistoryDataAccess
            {
                TodoItemId = todoItemId,
                Status = status,
                CreatedDate = date,
                LastUpdatedDate = date
            });
        }

        public void Delete(string id)
        {
            _todoItemStatusHistoryService.RetrieveByTodoItemId(id).ToList()
                .ForEach(history => _todoItemStatusHistoryService.Delete(history.Id));

            _todoItemService.Delete(id);
        }
    }
}