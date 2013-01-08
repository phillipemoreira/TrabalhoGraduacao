using System;
using System.Web.Mvc;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using NHibernate;
using Plan5W2HPlusPlus.Application.Controllers;
using Plan5W2HPlusPlus.Model.Models;
using System.IO;

namespace Plan5W2HPlusPlus.Application.ActionFilter
{
    public class NHibernateActionFilter : ActionFilterAttribute 
    {    
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();

        private static ISessionFactory BuildSessionFactory()
        {
            var cfg = new Configuration();
            cfg.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hibernate.cfg.xml"));
            return Fluently.Configure(cfg)
                      .Mappings(m =>
                        m.FluentMappings
                          .AddFromAssemblyOf<Plan5W2H>())
                          .ExposeConfiguration(BuildSchema)
                      .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {

            if (true)
            {
                // this NHibernate tool takes a configuration (with mapping info in)
                // and exports a database schema from it
                new SchemaExport(config).Execute(false, true, false);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            sessionController.ISession = sessionFactory.OpenSession();
            sessionController.ISession.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            using (var session = sessionController.ISession)
            {
                if (session == null)
                    return;

                if (!session.Transaction.IsActive)
                    return;

                if (filterContext.Exception != null)
                    session.Transaction.Rollback();
                else
                    session.Transaction.Commit();
            }
        }
    }
}