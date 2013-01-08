using System;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Application.Models;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter]
    public class Plan5W2HController : LoggedController
    {
        private IPlan5W2HService servicePlan5W2H;
        private IPlan5W2HService ServicePlan5W2H
        {
            get
            {
                if (servicePlan5W2H == null) servicePlan5W2H = new Plan5W2HService(RepPlan5W2H);
                return servicePlan5W2H;
            }

        }

        private IPlan5W2HRepository repPlan5W2H;
        private IPlan5W2HRepository RepPlan5W2H
        {
            get
            {
                if (repPlan5W2H == null) repPlan5W2H = new Plan5W2HRepository(this.ISession);
                return repPlan5W2H;
            }

        }

        private IUserService serviceUser;
        private IUserService ServiceUser
        {
            get
            {
                if (serviceUser == null) serviceUser = new UserService(RepUser);

                return serviceUser;
            }

        }

        private IUserRepository repUser;
        private IUserRepository RepUser
        {
            get
            {
                if (repUser == null) repUser = new UserRepository(this.ISession);

                return repUser;
            }

        }

        //
        // GET: /Plan5W2H/
        [Authorize]
        public ActionResult Index()
        {
            User usuario = this.GetUserAuthenticatedCookie();
            this.IncludUserViewBag();
            return View(usuario.Plans);
        }

        [Authorize]
        public ActionResult Create()
        {
            this.IncludUserViewBag();
            return View(new Plan5W2H());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Plan5W2H model)
        {
            try
            {
                User ususario = this.GetUserAuthenticatedCookie();
                ususario.Plans.Add(model);
                TryUpdateModel(ususario);
                this.IncludUserViewBag();

                ViewBag.Message = "SUCCESS";
                return View(model);
            }
            catch
            {
                ViewBag.Message = "ERROR";
                return View();
            }
        }

    }
}
