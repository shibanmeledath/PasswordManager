using Microsoft.EntityFrameworkCore;
using PasswordManager.API.Models.Domain;

namespace PasswordManager.API.Data
{
    public class PasswordsDbContext(DbContextOptions options):DbContext (options)
    {
        public DbSet<Passwords> Passwords { get; set; }
    }
}
