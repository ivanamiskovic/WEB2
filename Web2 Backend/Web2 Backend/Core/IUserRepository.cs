﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithEmail(string email);

        User GetUserWithUsernameAndPassword(string email, string password);
        List<User> GetVerificationUsers();
    }
}
