using Entity;

namespace Services
{
    public interface IUsersServices
    {
        User GetUserByID(int id);
        User Login(LoginUser loginUser);
        int RemoveUser(int id);
        Task<User> SignUp(User user);
        Task<User> UpdateUser(int id, User user);
    }
}