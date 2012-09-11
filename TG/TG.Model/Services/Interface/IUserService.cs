using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Models;

namespace TG.Model.Services
{
    public interface IUserService
    {
        User FindByUsernamePassword(string username, string password);
    }
}
