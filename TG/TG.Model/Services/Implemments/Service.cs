using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TG.Model.Services;
using TG.Model.Repository;

namespace TG.Model.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Get(object id)
        {
            return _repository.Get(id);
        }

        public void Save(T value)
        {
            _repository.Save(value);
        }
        public void Update(T value)
        {
            _repository.Update(value);
        }

        public void Delete(T value)
        {
            _repository.Delete(value);
        }
    }
}
