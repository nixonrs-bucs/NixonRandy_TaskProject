using NixonRandy_Project1.Models.Entities;
namespace NixonRandy_Project1.Services;
public interface IUserRepo
{
    public Task<User> DetailsAsync(int id);
    public Task<User> RegisterAsync(User user);
    public Task<User> LogoutAsync();
    public Task<User> DeleteAsync(int id);
}
