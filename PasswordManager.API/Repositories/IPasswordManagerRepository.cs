using PasswordManager.API.Models.Domain;

namespace PasswordManager.API.Repositories
{
    public interface IPasswordManagerRepository 
    {
      Task<Passwords> AddPasswordasync(Passwords passwords);
      Task<IEnumerable<Passwords>> GetPasswordsAsync(int pageNumber,int pageSize);
      Task<Passwords> GetPasswordByIdAsync (Guid id);
      Task UpdateChangesAsync();
      Task DeleteChangesAsync(Passwords passwords);
      Task<int> GetTotalPasswordsCountAsync();


    }
}
