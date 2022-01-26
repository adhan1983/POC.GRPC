using Microsoft.EntityFrameworkCore;
using Repo.POC.GRPC.Server.Repository.Models;

namespace Repo.POC.GRPC.Server.Repository.Context
{
    public class EmployeeGRPCServerContext : DbContext
    {
        public EmployeeGRPCServerContext(DbContextOptions<EmployeeGRPCServerContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");            
        }
    }
}
