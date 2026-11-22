using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Services
{
    public class PasswordStrength:IPasswordValidity
    {
        public int GetPasswordStrength(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
