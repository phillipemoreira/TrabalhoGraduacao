using NHibernate;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public class Plan5W2HRepository : Repository<Plan5W2H>, IPlan5W2HRepository
    {
        private readonly ISession session;
        public Plan5W2HRepository(ISession session)
            : base(session)
        {
            this.session = session;
        }
    }
}
