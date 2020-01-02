using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options){
            Database.EnsureCreated();
        }
    }
}
