using Plan5W2HPlusPlus.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Plan5W2HPlusPlus.Model.Services
{
    public interface IService<T>
    {
        T Get(object id);
        void Save(T value);
        void SaveOrUpdate(T value);
        void Update(T value);
        void Delete(T value);
        IList<T> GetWhere(Expression<Func<T, bool>> where);
        IList<T> GetAll();
    }
}
