using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;
using ToDoAPI.Data;

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        IRepository repo;
        public ToDoController(IRepository repository) {
            repo = repository;
        
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAll()
        {
            return await repo.GetAll<ToDoItem>();
            
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetItem(int id)
        {
            var todo = await repo.Get<ToDoItem>(id);
            if (todo == null) {
                return NotFound();
            }
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> Create([FromBody] ToDoItem value)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await repo.Add<ToDoItem>(value);
            return CreatedAtAction(nameof(GetItem), new { id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoItem value)
        {
            if (id != value.Id) {
                return BadRequest();
            }
            await repo.Update<ToDoItem>(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> Delete(int id)
        {
            var item = await repo.Get<ToDoItem>(id);
            if (item == null) {
                return NotFound();
            }
            await repo.Delete<ToDoItem>(item);
            return item;
        }
    }
}
