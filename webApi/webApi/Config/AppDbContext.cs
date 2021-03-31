using System;
using Microsoft.EntityFrameworkCore;
using webApi.Domain.Entities;

namespace webApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"server=localhost;port=5432;database=postgres;user id=postgres;password=root;");
        }
    }
}
