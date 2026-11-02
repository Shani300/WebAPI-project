using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WebApi;
//using Zxcvbn;


namespace Repository
{
    public class UsersRepository
    {
        private const string filePath = "./users.txt";

        public User Login(LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password == loginUser.Password)
                        return user;
                }
            }
            return null;
        }

        public User SignIn(User user)
        {
            if (passwordValidation(user.Password)<=2)
            {
                return null;
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public bool Update(User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserID == userToUpdate.UserID)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }
            return true;
        }


        public User GetUserByID(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserID == id)
                        return user;
                }
            }
            return null;
        }

        public int RemoveUser(int id)
        {
            //Emplemantion needed
            return -1;
        }

        private static int passwordValidation(string password)
        {
            return 3;// Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
