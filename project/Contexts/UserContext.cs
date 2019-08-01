using DotnetCore.project.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.project.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) {}
    }
} 