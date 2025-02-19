using Microsoft.EntityFrameworkCore;
using PasswordManager.API.Data;
using PasswordManager.API.Models.Domain;

namespace PasswordManager.API.Repositories
{
    public class PSQLPasswordRepository(PasswordsDbContext dbContext) : IPasswordManagerRepository
    {
        private readonly PasswordsDbContext dbContext = dbContext;

        public async Task<Passwords> AddPasswordasync(Passwords passwords)
        {
            await dbContext.Passwords.AddAsync(passwords);
            await dbContext.SaveChangesAsync();
            return passwords;
        }

     

        public async Task DeleteChangesAsync(Passwords passwords)
        {
           dbContext.Remove(passwords);
           await dbContext.SaveChangesAsync();
        }

        public async Task<Passwords> GetPasswordByIdAsync(Guid id)
        {
            var password = await dbContext.Passwords.FirstOrDefaultAsync(p => p.Id == id);
            if (password == null)
            {
                return null;
            }
            return password;
        }

        public async Task<IEnumerable<Passwords>> GetPasswordsAsync()=> await dbContext.Passwords.ToListAsync();

        public async  Task UpdateChangesAsync()
        {
          
            await dbContext.SaveChangesAsync();
           
        }

     
    }
}
