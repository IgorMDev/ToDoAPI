using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        ToDoContext db;
        public ToDoController(ToDoContext context, ILogger<ToDoController> logger) {
            db = context;
            _logger = logger;
            if (!db.ToDoItems.Any()){
                db.ToDoItems.AddRange(
                    new ToDoItem {Name = "Todo1", Text = "Text1" },
                    new ToDoItem { Name = "Todo2", Text = "Text2" }
                );
                db.SaveChanges();
            }
        }
        // GET: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetItems(){
            return await db.ToDoItems.ToListAsync();
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetItem(int id)
        {
            var todo = await db.ToDoItems.FirstAsync(el => el.Id == id);
            if (todo == null) {
                return NotFound();
            }
            return new ObjectResult(todo);
        }

        // POST: api/ToDo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItem value)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            db.ToDoItems.Add(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/ToDo/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ToDoItem value)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            db.ToDoItems.Update(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await db.ToDoItems.FirstAsync(el => el.Id == id);
            if(todo == null) {
                return NotFound();
            }
            db.ToDoItems.Remove(todo);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
