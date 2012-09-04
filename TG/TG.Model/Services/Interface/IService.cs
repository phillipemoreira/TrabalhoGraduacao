using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.Model.Services
{
    public interface IService<T>
    {
        IList<T> GetAll();
        T Get(object id);
        void Save(T value);
        void Update(T value);
        void Delete(T value);
    }
}
