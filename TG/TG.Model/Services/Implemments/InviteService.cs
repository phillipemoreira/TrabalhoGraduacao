using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Services
{
    public class InviteService : Service<Invite>, IInviteService
    {
        private readonly IInviteRepository _repository;
        public InviteService(IInviteRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
