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

        public TodoItemRetrieve Create(TodoItemCreate item)
        {
            var now = DateTime.UtcNow;
            var status = TodoItemStatus.Pending;

            var objectToCreate = TodoItemMapper.ToDataAccess(item, now, status);

            var createdThing = _todoItemService.Create(objectToCreate);

            var history = _todoItemStatusHistoryService.Create(new TodoItemStatusHistoryDataAccess
            {
                TodoItemId = createdThing.Id,
                Status = status,
                CreatedDate = now,
                LastUpdatedDate = now
            });

            return TodoItemMapper.ToController(createdThing, new List<TodoItemStatusHistoryDataAccess> { history });
        }
    }
}