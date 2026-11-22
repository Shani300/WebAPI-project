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

        public User Login(LoginUser loginUser)
        {
            User user = _dbContext.Users.ToList().Find(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
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
            _dbContext.SaveChangesAsync().Wait();
            return user;//???????
        }


        public User GetUserByID(int id)
        {
            User user = _dbContext.Users.ToList().Find(u => u.Id == id);
            return user;
        }

        public int RemoveUser(int id)
        {
            User userToRemove = GetUserByID(id);
            _dbContext.Remove(userToRemove);
            _dbContext.SaveChanges();
            return userToRemove.Id;
        }

    }
}
