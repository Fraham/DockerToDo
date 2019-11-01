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
            /*var TodoItem = _TodoItemService.Get(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            return TodoItem;*/

            return null;
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
            /*var TodoItem = _TodoItemService.Get(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            _TodoItemService.Update(id, TodoItemIn);
            */

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            /* 
            var TodoItem = _TodoItemService.Get(id);

            if (TodoItem == null)
            {
                return NotFound();
            }

            _TodoItemService.Remove(TodoItem.Id);

            */

            return NoContent();
        }
    }
}