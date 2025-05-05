using Microsoft.EntityFrameworkCore;
using NixonRandy_Project1.Models.Entities;
using Microsoft.AspNetCore.Identity;
using NixonRandy_Project1.Data;
namespace NixonRandy_Project1.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> DetailsAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<User> RegisterAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> LoginAsync(User user)
        {
            var loggedInUser = await _db.Users
                .FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            if (loggedInUser != null)
            {
                
            }
                return loggedInUser;
        }

        /*public async Task LogoutAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if(user != null)
            {
                
                user.UpdatedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }*/

        public async Task DeleteAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}
