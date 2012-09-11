using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Models;
using NHibernate;

namespace TG.Model.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ISession session;
        public UserRepository(ISession session)
            : base(session)
        {
            this.session = session;
        }
        
        public User  FindByUsernamePassword(string username, string password)
        {
            return session
                .QueryOver<User>()
                .Where(x => x.UserName == username)
                .And(x => x.Password == password)   
                .SingleOrDefault();
        }
    }
}
