using NHibernate;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public class InviteRepository : Repository<Invite>, IInviteRepository
    {
        private readonly ISession session;
        public InviteRepository(ISession session)
            : base(session)
        {
            this.session = session;
        }
    }
}
