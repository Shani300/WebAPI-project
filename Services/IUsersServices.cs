using Entity;

namespace Services
{
    public interface IUsersServices
    {
        User GetUserByID(int id);
        User Login(LoginUser loginUser);
        int RemoveUser(User userToRemove);
        User SignIn(User user);
        bool Update(User user);
    }
}