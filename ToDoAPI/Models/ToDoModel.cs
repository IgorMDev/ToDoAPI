using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models
{
    public class ToDoItem{
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool isCompleted { get; set; }
    }
}
