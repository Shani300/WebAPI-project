using Entity;

namespace Repository
{
    public interface IUsersRepository
    {
        User GetUserByID(int id);
        User Login(LoginUser loginUser);
        int RemoveUser(int id);
        User SignUp(User user);
        bool Update(User userToUpdate);
    }
}