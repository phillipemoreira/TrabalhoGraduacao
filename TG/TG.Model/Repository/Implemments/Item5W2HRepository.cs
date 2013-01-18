using NHibernate;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public class Item5W2HRepository : Repository<Item5W2H>, IItem5W2HRepository
    {
        private readonly ISession session;
        public Item5W2HRepository(ISession session)
            : base(session)
        {
            this.session = session;
        }
    }
}
