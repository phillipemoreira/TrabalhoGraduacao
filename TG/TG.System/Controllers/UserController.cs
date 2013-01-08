using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter]
    public class UserController : LoggedController
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
            User usuario = this.GetUserAuthenticatedCookie();
            this.IncludUserViewBag();
            if(usuario != null)
                return View(usuario);
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User usuario)
        {
            try
            {
                User userSession = this.GetUserAuthenticatedCookie();
                if (userSession != null)
                {
                    usuario = Service.Get(usuario.Code);
                    TryUpdateModel(usuario);
                    this.IncludUserViewBag();
                }
                else
                {
                    Service.Save(usuario);
                }
                
                ViewBag.Message = "SUCCESS";
                return View(usuario);
            }
            catch
            {
                ViewBag.Message = "ERROR";
                return View(usuario);
            }
        }
    }
}
