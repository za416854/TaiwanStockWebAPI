using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebAPI; 

namespace TestWebAPI.Data
{
    public class TestWebAPIContext : DbContext
    {
        public TestWebAPIContext (DbContextOptions<TestWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Sales> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>().HasNoKey();
        }

    }
}
