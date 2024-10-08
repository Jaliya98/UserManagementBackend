using Microsoft.EntityFrameworkCore;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserRegister> Users { get; set; }
    }
}
