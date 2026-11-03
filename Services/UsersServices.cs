using Repository;
using Entity;

namespace Services
{
    public class UsersServices
    {
        private UsersRepository usersRepository=new UsersRepository();

        public User Login(LoginUser loginUser)
        {
            User user=usersRepository.Login(loginUser);
            if(user != null ) 
                return user;
            return null;
        }

        public User SignIn(User user)
        {
            return usersRepository.SignUp(user);
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
