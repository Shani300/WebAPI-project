using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IPasswordValidity
    {
        public int GetPasswordStrength(string password);
    }
}
