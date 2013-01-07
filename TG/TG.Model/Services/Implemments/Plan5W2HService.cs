using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Services
{
    public class Plan5W2HService : Service<Plan5W2H>, IPlan5W2HService
    {
        private readonly IPlan5W2HRepository _repository;
        public Plan5W2HService(IPlan5W2HRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
