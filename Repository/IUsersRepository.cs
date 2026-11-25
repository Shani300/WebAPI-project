using Entity;

namespace Repository
{
    public interface IUsersRepository
    {
        Task<User> AddUser(User user);
        Task<User> GetUserByID(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> UpdateUser(int id,User userToUpdate);

        int RemoveUserAsync(int id);

    }
}