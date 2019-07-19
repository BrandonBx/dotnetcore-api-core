using ExpensesManaging.project.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManaging.project.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}
    }
} 