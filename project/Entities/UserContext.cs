using ExpensesManaging.project.POCO;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManaging.project.Entities
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
    }
} 