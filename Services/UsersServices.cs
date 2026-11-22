using Repository;
using Entity;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        private IUsersRepository usersRepository;
        private IPasswordValidity passwordValidity;

        public UsersServices(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
            this.passwordValidity = new PasswordStrength();
        }

        public User Login(LoginUser loginUser)
        {
            User user = usersRepository.Login(loginUser);
            if (user != null)
                return user;
            return null;
        }

        public async Task<User> SignUp(User user)
        {
            if (passwordValidity.GetPasswordStrength(user.Password) <= 2)
                return null;
            return await usersRepository.AddUser(user);
        }

        public User GetUserByID(int id)
        {
            return usersRepository.GetUserByID(id);
        }

        public int RemoveUser(int id)
        {
            return usersRepository.RemoveUser(id);
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            return await usersRepository.UpdateUser(id, user);
        }
    }
}
