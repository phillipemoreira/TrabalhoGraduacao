using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Models;
using TG.Model.Repository;

namespace TG.Model.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
        
        public User FindByUsernamePassword(string username, string password)
        {
            return _repository.FindByUsernamePassword(username, password);
        }
    }
}
