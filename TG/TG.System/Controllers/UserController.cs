using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TG.Application.ActionFilter;
using TG.Model.Services;
using TG.Model.Models;
using TG.Model.Repository;

namespace TG.Application.Controllers
{
    [NHibernateActionFilter]
    public class UserController : SessionController
    {
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
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            try
            {
                Service.Save(model);
                ViewBag.Success = true;
                return View(model);
            }
            catch
            {
                ViewBag.Success = false;
                return View(model);
            }
        }
    }
}
