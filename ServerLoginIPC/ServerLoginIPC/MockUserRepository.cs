using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLoginIPC
{
    class MockUserRepository
    {
        List<User> users = new List<User>();
        // Function to add the user to im memory dummy DB
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public void ResetUsers()
        {
            users.Clear();
        }
        // Function to retrieve the user based on user id
        public User GetUser(string userid)
        {
            try
            {
                return users.Single(u => u.UserId == userid);
            }
            catch
            {
                return users.First();
            }
        }
    }
}
