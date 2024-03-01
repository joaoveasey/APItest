using APItest.Model;
using Microsoft.EntityFrameworkCore;

namespace APItest.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JLE3IV2Q;Database=Employees; Trusted_Connection = True; TrustServerCertificate=True;");
    }
}
