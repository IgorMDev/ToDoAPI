using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Data
{
    public class ToDoRepository : EFCoreRepository<ToDoContext>
    {
        public ToDoRepository(ToDoContext ctx) : base(ctx)
        {
            
        }
    }
}
