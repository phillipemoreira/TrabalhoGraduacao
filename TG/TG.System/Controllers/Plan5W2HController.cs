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
    [Authorize]
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
        public ActionResult Index()
        {
            User usuario = this.GetUserAuthenticatedCookie();
            this.IncludUserViewBag();
            return View(usuario.Plans);
        }

        public ActionResult Create(string id)
        {
            this.IncludUserViewBag();
            if (id != null)
            {
                Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id.ToString()));
                return View(plan);
            }
            return View(new Plan5W2H());
        }

        [HttpPost]
        public ActionResult Create(Plan5W2H model)
        {
            try
            {
                User usuario;
                if (ServicePlan5W2H.Get(model.Code) != null)
                {
                    usuario = (User)ISession.Load(typeof(User), new Guid(this.GetUserIDAuthenticatedCookie()));
                    Plan5W2H plan = ServicePlan5W2H.Get(model.Code);
                    usuario.Plans.Remove(plan);
                    usuario.Plans.Add(model);
                    ISession.Merge(usuario);
                }
                else
                {
                    usuario = this.GetUserAuthenticatedCookie();
                    usuario.Plans.Add(model);
                }
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

        public ActionResult Remove(string id)
        {

            User usuario = this.GetUserAuthenticatedCookie();
            if (id != null)
            {
                Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id.ToString()));
                usuario.Plans.Remove(plan);
            }
            this.IncludUserViewBag();
            return RedirectToAction("Index");
        }

        public ActionResult FinalizeProject(string id)
        {
            User usuario = (User)ISession.Load(typeof(User), new Guid(this.GetUserIDAuthenticatedCookie()));
            Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id));
            usuario.Plans.Remove(plan);
            plan.Andamento = Status.Finalizado;
            usuario.Plans.Add(plan);
            ISession.Merge(usuario);

            return RedirectToAction("Index");
        }

        public ActionResult OpenProject(string id)
        {
            User usuario = (User)ISession.Load(typeof(User), new Guid(this.GetUserIDAuthenticatedCookie()));
            Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id));
            usuario.Plans.Remove(plan);
            plan.Andamento = Status.EmAndamento;
            usuario.Plans.Add(plan);
            ISession.Merge(usuario);
            return RedirectToAction("Index");
        }
    }
}
