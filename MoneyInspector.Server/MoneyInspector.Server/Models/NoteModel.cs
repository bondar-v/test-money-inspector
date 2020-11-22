using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Notice { get; set; }
        public double Price { get; set; }
        public CategoryModel Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
