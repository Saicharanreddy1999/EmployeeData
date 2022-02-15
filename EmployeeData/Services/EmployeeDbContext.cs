using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeData.Services
{
    public class EmployeeDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Dept> Department { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("EmpConnection");
                optionsBuilder.UseMySQL(connectionString);
                
            }
            


           // optionsBuilder.UseMySQL("server=localhost;database=emp;user=sai,password=sai");
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.DeptId).IsRequired();


            });
            modelbuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(d => d.DeptId);
                entity.Property(d=>d.DeptName).IsRequired();
            }

            );
            
        }
    }
}
