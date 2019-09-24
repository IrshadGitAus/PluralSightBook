using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluralSightBook.Core.Services
{
    public class UserService
    {
        private readonly IQueryUsersByEmail _queryUsersByEmail;
        public UserService(IQueryUsersByEmail queryUsersByEmail)
        {
            _queryUsersByEmail = queryUsersByEmail;
        }

        public bool isEmailRegistered(string email)
        {
            return _queryUsersByEmail.UserWithEmailExists(email);
        }

        public User GetUserByEmail(string email)
        {
            return _queryUsersByEmail.GetUserByEmail(email);
        }
    }
}
