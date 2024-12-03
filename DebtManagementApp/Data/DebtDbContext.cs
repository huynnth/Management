using Microsoft.EntityFrameworkCore;
using DebtManagementApp.Models;

namespace DebtManagementApp.Data
{
    public class DebtDbContext : DbContext
    {
        public DebtDbContext(DbContextOptions<DebtDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Debt> Debts { get; set; }
    }
}
