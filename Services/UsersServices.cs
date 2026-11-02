using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WebApi;

namespace Services
{
    public class UsersServices
    {
        private UsersRepository usersRepository;

        public User Login(LoginUser loginUser)
        {
            User user=usersRepository.Login(loginUser);
            if(user != null ) 
                return user;
            return null;
        }

        public User SignIn(User user)
        {
            return usersRepository.SignIn(user);
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
