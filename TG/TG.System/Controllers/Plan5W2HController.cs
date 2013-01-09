using System;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using System.Collections.Generic;

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
            IList<Plan5W2H> plans = ISession.QueryOver<Plan5W2H>()
                                        .Where(p => p.Owner == this.Usuario)
                                        .List();
            this.IncludUserViewBag();
            return View(plans);
        }

        public ActionResult Create(string id)
        {
            this.IncludUserViewBag();
            Plan5W2H plan;
            if (id != null)
            {
                plan = ServicePlan5W2H.Get(new Guid(id.ToString()));
                return View(plan);
            }
            return View(new Plan5W2H());
        }

        [HttpPost]
        public ActionResult Create(Plan5W2H model)
        {
            try
            {
                User usuario = this.Usuario;
                
                if (model.Owner == null)
                    model.Owner = usuario;

                if (ServicePlan5W2H.Get(model.Code) != null)
                {
                    Plan5W2H plan = ServicePlan5W2H.Get(model.Code);
                    usuario.Plans.Remove(plan);
                    usuario.Plans.Add(model);
                    ISession.Merge(usuario);
                }
                else
                {
                    
                    this.Usuario.Plans.Add(model);
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

            if (id != null)
            {
                Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id.ToString()));
                this.Usuario.Plans.Remove(plan);
            }
            this.IncludUserViewBag();
            return RedirectToAction("Index");
        }

        public ActionResult FinalizeProject(string id)
        {
            User usuario = this.Usuario;
            Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id));
            usuario.Plans.Remove(plan);
            plan.Andamento = Status.Finalizado;
            usuario.Plans.Add(plan);
            ISession.Merge(usuario);

            return RedirectToAction("Index");
        }

        public ActionResult OpenProject(string id)
        {
            User usuario = this.Usuario;
            Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id));
            usuario.Plans.Remove(plan);
            plan.Andamento = Status.EmAndamento;
            usuario.Plans.Add(plan);
            ISession.Merge(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Ordenacao(int ordem)
        {
            
                                            

            return View();
        }
    }
}
