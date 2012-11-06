using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TG.Application.ActionFilter;
using TG.Model.Models;
using TG.Model.Repository;
using TG.Model.Services;
using System.Web.Security;
using TG.Application.Util;

namespace TG.Application.Controllers
{
    [NHibernateActionFilter]
    public class Plan5W2HController : SessionController
    {

        private String UserLoggedCode;

        private IService<Plan5W2H> servicePlan5W2H;
        private IService<Plan5W2H> ServicePlan5W2H
        {
            get
            {
                if (servicePlan5W2H == null) servicePlan5W2H = new Service<Plan5W2H>(RepPlan5W2H);

                return servicePlan5W2H;
            }

        }

        private IRepository<Plan5W2H> repPlan5W2H;
        private IRepository<Plan5W2H> RepPlan5W2H
        {
            get
            {
                if (repPlan5W2H == null) repPlan5W2H = new Repository<Plan5W2H>(this.ISession);

                return repPlan5W2H;
            }

        }

        private IService<User> service;
        private IService<User> Service
        {
            get
            {
                if (service == null) service = new Service<User>(RepUser);

                return service;
            }

        }

        private IRepository<User> repUser;
        private IRepository<User> RepUser
        {
            get
            {
                if (repUser == null) repUser = new Repository<User>(this.ISession);

                return repUser;
            }

        }

        //
        // GET: /Plan5W2H/

        public ActionResult Index()
        {
            //if (HttpContext != null)
            //    this.UserLoggedCode = Tools.retrieveUserFromCookie(HttpContext.ApplicationInstance as MvcApplication);
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
