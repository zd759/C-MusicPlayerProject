using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoginIPC
{
    //password manager adds a generated salt value to a plain password and returns it. it also can check
    // if a string password matches one created using hashing
    class PasswordManager
    {
        HashComputer m_hashComputer = new HashComputer();
        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();
            string finalString = plainTextPassword + salt;
            return m_hashComputer.GetPasswordHashAndSalt(finalString);
        }
        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == m_hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }
}
