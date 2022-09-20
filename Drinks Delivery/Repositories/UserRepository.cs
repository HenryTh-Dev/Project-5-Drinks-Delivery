using Drinks_Delivery.Interface;
using Drinks_Delivery.Models;
using System;
using System.Collections.Generic;

namespace Drinks_Delivery.Repositories
{

    public class UserRepository : IUserRepository
    {

        private List<User> Users = new List<User>();


        public bool CreateAccount(string newEmail, string password, string fullName, string ssn, string birthdate, string address)
        {

            User userR = new User() { Email = newEmail, Address = address, Password = password, Name = fullName, SSN = ssn, Birthdate = birthdate, ID = Users.Count };
            Users.Add(userR);
            return true;

        }

        public int LoginAccount(string typedEmail, string typedPass)
        {
            Console.Clear();
            var realUser = Users.Find(x => x.Email == typedEmail);
            if(realUser == null)
            {
                if (typedEmail == "admin" && typedPass == "admin")
                {
                    return 1;
                }
                
                return 2;
            }

            if (typedPass != realUser.Password)
            {
                
                return 3;
            }
            return 4;
        }
        public bool ValidateEmail(string newEmail)
        {
            var Validate = Users.Find(c => c.Email == newEmail);
            if (Validate == null)
            {
                return false;
            }
            return true;
        }
    }
}
