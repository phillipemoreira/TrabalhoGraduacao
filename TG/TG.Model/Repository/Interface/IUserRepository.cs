using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Models;

namespace TG.Model.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsernamePassword(string username, string password);
    }
}
