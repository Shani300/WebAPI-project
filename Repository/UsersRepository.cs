using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Entity;
using System.Linq;

namespace Repository
{
    public class UsersRepository : IUsersRepository
    {

        MyShopContext _dbContext;
        public UsersRepository(MyShopContext myShopContext)
        {
            _dbContext = myShopContext;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id,User userToUpdate)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;
            _dbContext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return user;
        }


        public async Task<User> GetUserByID(int id)
        {
            User user = await _dbContext.Users.FindAsync(id);
            return user;
        }

        public int RemoveUserAsync(int id)
        {
            return -1;
        }

        //public async Task<int> RemoveUserAsync(int id)
        //{
        //    User userToRemove = await GetUserByID(id);
        //    _dbContext.Remove(userToRemove);
        //    _dbContext.SaveChanges();
        //    return userToRemove.Id;
        //}

    }
}
