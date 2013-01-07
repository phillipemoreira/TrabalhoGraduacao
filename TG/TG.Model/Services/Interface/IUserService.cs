using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;

namespace Plan5W2HPlusPlus.Model.Services
{
    public interface IUserService : IService<User>
    {
        User FindByUsernamePassword(string username, string password);

        User FindByCode(Guid code);
    }
}
