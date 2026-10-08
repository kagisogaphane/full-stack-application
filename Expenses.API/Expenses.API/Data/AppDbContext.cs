namespace Expenses.API.Data
{
    using Expenses.API.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext (options)
    {
    
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
    }
}
