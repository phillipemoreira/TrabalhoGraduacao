using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Services
{
    public class Item5W2HService : Service<Item5W2H>, IItem5W2HService
    {
        private readonly IItem5W2HRepository _repository;
        public Item5W2HService(IItem5W2HRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
