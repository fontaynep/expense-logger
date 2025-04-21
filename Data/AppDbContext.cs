using Microsoft.EntityFrameworkCore;
using ExpenseLogger.Models;
using ExpenseLogger.Data;


namespace ExpenseLogger.Data
    {
    public class AppDbContext : DbContext
        {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
            {
            }

        public DbSet<Expense> Expenses
            {
            get; set;
            }
        }
    }
