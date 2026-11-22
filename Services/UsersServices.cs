using Repository;
using Entity;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        private IUsersRepository usersRepository;

        //Who gives the service an IUsersRepository? The assignment asks to register it in Program.cs with AddScoped, using the interface as the service type
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
            //Update doesn't call the repository, so the user is never saved. Should it call usersRepository.Update?
            return true;
        }
    }
}
