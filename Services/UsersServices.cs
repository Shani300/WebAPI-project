using Repository;
using Entity;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        private IUsersRepository usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public User Login(LoginUser loginUser)
        {
            User user = usersRepository.Login(loginUser);
            if (user != null)
                return user;
            return null;
        }

        public User SignIn(User user)
        {
            return usersRepository.AddUser(user);
        }

        public User GetUserByID(int id)
        {
            return usersRepository.GetUserByID(id);
        }

        public int RemoveUser(User userToRemove)
        {
            return usersRepository.RemoveUser(userToRemove.UserID);
        }

        public bool Update(User user)
        {
            return true;
        }
    }
}
