using Entity;

namespace Repository
{
    public interface IUsersRepository
    {
        Task<User> AddUser(User user);
        User GetUserByID(int id);
        User Login(LoginUser loginUser);
        int RemoveUser(int id);
        Task<User> UpdateUser(int id,User userToUpdate);
    }
}