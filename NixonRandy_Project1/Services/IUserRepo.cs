using NixonRandy_Project1.Models.Entities;
namespace NixonRandy_Project1.Services;
using NixonRandy_Project1.Data;
public interface IUserRepo
{
    public Task<User> DetailsAsync(int id);
    public Task<User> RegisterAsync(User user);
    public Task<User?> LoginAsync(User user);
    //public Task LogoutAsync(int id);
    public Task DeleteAsync(int id);
}
