﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsernameAndPassword(string username, string password);

        User FindByCode(Guid code);
    }
}
