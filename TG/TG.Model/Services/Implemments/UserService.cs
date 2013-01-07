using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;

namespace Plan5W2HPlusPlus.Model.Services
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
            return _repository.FindByUsernameAndPassword(username, password);
        }

        public User FindByCode(Guid code)
        {
            return _repository.FindByCode(code);
        }
    }
}
