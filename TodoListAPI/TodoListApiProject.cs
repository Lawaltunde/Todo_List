using TodListModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListApiProject 
    {
        private readonly BloggingContext _context;

        public TodoListApiProject(BloggingContext context)
        {
            _context = context;
        }

        // GET api/todoitems
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return _context.TodoItems.Where(item => item.CompletedDate == null).ToList();
        }

        // GET api/todoitems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            return _context.TodoItems.FirstOrDefault(item => item.Id == id);
        }

        // POST api/todoitems
        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody] TodoItem item)
        {
            item.DueDate = DateTime.Now;
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return item;
        }

        // POST api/todoitems/5
        [HttpPost("{id}")]
        public ActionResult<TodoItem> Post(int id)
        {
            var item = _context.TodoItems.FirstOrDefault(item => item.Id == id);
            if (item != null)
            {
                item.CompletedDate = DateTime.Now;
                _context.SaveChanges();
            }
            return item;
        }
    }
}
