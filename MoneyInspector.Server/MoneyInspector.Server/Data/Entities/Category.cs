using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Notes = new List<Note>();
        }

        public string Name { get; set; }
        public List<Note> Notes { get; set; }
    }
}
