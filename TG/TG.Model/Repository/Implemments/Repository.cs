using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using System.Linq.Expressions;

namespace Plan5W2HPlusPlus.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected Configuration config;
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        private static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure(new Configuration().Configure())
                      .Mappings(m =>
                        m.FluentMappings
                          .AddFromAssemblyOf<T>())

                      .BuildSessionFactory();
        }

        public void Save(T value)
        {
            session.Save(value);
        }

        public void SaveOrUpdate(T value)
        {
            session.SaveOrUpdate(value);
        }

        public void Update(T value)
        {
            session.Update(value);
        }

        public void Delete(T value)
        {
            session.Delete(value);
        }

        public virtual T Get(object id)
        {
            return session.Get<T>(id);
        }

        public virtual IList<T> GetWhere(Expression<Func<T,bool>> where)
        {
            return session.QueryOver<T>().Where(where).List();
        }

        public IList<T> GetAll()
        {
            return session.CreateCriteria(typeof(T)).List<T>();
        }
    }
}
