using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Models
{
    public class NewNoteModel
    {
        public int CategoryId { get; set; }
        public string Notice { get; set; }
        public double Price { get; set; }
    }
}
