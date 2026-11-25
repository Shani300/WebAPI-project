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

        public async Task<User> Login(LoginUser loginUser)
        {
            User user =await usersRepository.Login(loginUser);
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

        public async Task<User> GetUserByID(int id)
        {
            return await usersRepository.GetUserByID(id);
        }


        public async Task<User> UpdateUser(int id, User user)
        {
            return await usersRepository.UpdateUser(id, user);
        }

        public int RemoveUser(int id)
        {
            return usersRepository.RemoveUserAsync(id);
        }
    }
}
