using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Data.Entities
{
    public class Note : BaseEntity
    {
        public string Notice { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
