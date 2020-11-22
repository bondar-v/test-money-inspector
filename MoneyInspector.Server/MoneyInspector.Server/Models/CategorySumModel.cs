using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Models
{
    public class CategorySumModel
    {
        public CategoryModel Category { get; set; }
        public double Sum { get; set; }
    }
}
