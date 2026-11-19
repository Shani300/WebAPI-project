using Entity;

namespace Repository
{
    public interface IUsersRepository
    {
        User GetUserByID(int id);
        User Login(LoginUser loginUser);
        User AddUser(User user);
        int RemoveUser(int id);
        bool Update(User userToUpdate);
    }
}