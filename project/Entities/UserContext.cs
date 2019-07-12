using ExpensesManaging.project.POCO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManaging.project.Entities
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
} 