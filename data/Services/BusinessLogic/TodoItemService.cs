using System.Collections.Generic;
using Data.Mappers;
using Data.Models.Controller.TodoItem;
using Data.Services.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace Data.Services.BusinessLogic 
{
    public class TodoItemService : BaseService, ITodoItemService
    {
        private Data.Services.DataAccess.Interfaces.ITodoItemService _todoItemService;

        public TodoItemService(ILogger<BaseService> logger, Data.Services.DataAccess.Interfaces.ITodoItemService todoItemService) : base(logger)
        {
            _todoItemService = todoItemService;
        }

        public IEnumerable<TodoItemRetrieve> GetAll()
        {
            var items = _todoItemService.Retrieve();

            return TodoItemMapper.ToController(items);
        }
    }
}