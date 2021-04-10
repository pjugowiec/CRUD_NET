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
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;port=5432;database=postgres;user id=postgres;password=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasOne(a => a.EmployeeEntity)
                .WithOne(b => b.UserEntity);

            modelBuilder.Entity<AddressEntity>()
                .HasMany(a => a.EmployeeEntities)
                .WithOne(b => b.AddressEntity);

            modelBuilder.Entity<DepartmentEntity>()
                .HasMany(a => a.EmployeeEntities)
                .WithOne(b => b.DepartmentEntity);

            modelBuilder.Entity<DepartmentEntity>()
                .HasMany(a => a.ProjectEntities)
                .WithOne(b => b.DepartmentEntity);

            // ManyToMany
            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasKey(bc => new { bc.EmployeeId, bc.ProjectId });

            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne(bc => bc.EmployeeEntity)
                .WithMany(b => b.EmployeeProjects)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne(bc => bc.ProjectEntity)
                .WithMany(b => b.EmployeeProjects)
                .HasForeignKey(bc => bc.ProjectId);
        }

    }
}
