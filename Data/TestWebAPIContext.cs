using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestWebAPI; 

namespace TestWebAPI.Data
{
    public class TestWebAPIContext : DbContext
    {
        
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        // Dapper的建構式
        public TestWebAPIContext(IConfiguration configuration//, TWLEncrypyt twlEncrypyt
            )
        {
            _configuration = configuration;

            string encryptString = _configuration.GetConnectionString("DefaultConnection");

            //_connectionString = twlEncrypyt.Decrypt(encryptString);
            _connectionString = encryptString;
        }
        public TestWebAPIContext(DbContextOptions<TestWebAPIContext> options)
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
