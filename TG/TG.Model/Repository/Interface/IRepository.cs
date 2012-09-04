using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Repository
{
    public interface IRepository<T>
    {
        T Get(object id);
        void Save(T value);
        void Update(T value);
        void Delete(T value);
        IList<T> GetAll();
    }
}
