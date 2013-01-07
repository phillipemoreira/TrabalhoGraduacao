using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plan5W2HPlusPlus.Model.Models;
using NHibernate;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ISession session;
        public UserRepository(ISession session)
            : base(session)
        {
            this.session = session;
        }
        
        public User  FindByUsernameAndPassword(string username, string password)
        {
            return session
                .QueryOver<User>()
                .Where(x => x.UserName == username)
                .And(x => x.Password == password)   
                .SingleOrDefault();
        }


        public User FindByCode(Guid code)
        {
            return session
                .QueryOver<User>()
                .Where(x => x.Code == code)
                .SingleOrDefault();
        }
    }
}
