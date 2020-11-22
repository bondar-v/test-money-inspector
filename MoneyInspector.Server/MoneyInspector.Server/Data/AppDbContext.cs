using Microsoft.EntityFrameworkCore;
using MoneyInspector.Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
