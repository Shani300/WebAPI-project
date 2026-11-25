using Entity;

namespace Services
{
    public interface IUsersServices
    {
        Task<User> GetUserByID(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> SignUp(User user);
        Task<User> UpdateUser(int id, User user);
        int RemoveUser(int id);

    }
}