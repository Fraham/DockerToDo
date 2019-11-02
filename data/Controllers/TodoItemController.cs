using Data.Models;
using Data.Models.Controller.TodoItem;
using Data.Services;
using Data.Services.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : BaseController
    {
        private ITodoItemService _itemService;

        public TodoItemController(ILogger<TodoItemController> logger, ITodoItemService itemService) : base(logger)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItemRetrieve>> Get()
        {
            return Ok(_itemService.GetAll());
        }

        [HttpGet("{id:length(24)}", Name = "GetTodoItem")]
        public ActionResult<TodoItemRetrieve> Get(string id)
        {
            return Ok(_itemService.Get(id));
        }

        [HttpPost]
        public ActionResult<TodoItemRetrieve> Create(TodoItemCreate todoItem)
        {
            var createdItem = _itemService.Create(todoItem);

            return CreatedAtRoute("GetTodoItem", new { id = createdItem.Id.ToString() }, createdItem);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TodoItemUpdate todoItemIn)
        {
            _itemService.Update(id, todoItemIn);            

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            _itemService.Delete(id);

            return NoContent();
        }
    }
}