using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;

namespace TG.Model.Repository
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

        public void Update(T value)
        {
            session.Update(value);
        }

        public void Delete(T value)
        {
            session.Delete(value);
        }

        T IRepository<T>.Get(object id)
        {
            return Get(id);
        }

        public virtual T Get(object id)
        {
            return session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            return session.CreateCriteria(typeof(T)).List<T>();
        }
    }
}
