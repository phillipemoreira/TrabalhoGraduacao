using System;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using System.Collections.Generic;
using Plan5W2HPlusPlus.Application.Models;
using System.Globalization;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter(Order = 1)]
    [AuthorizationActionFilter(Order = 2)]
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

        private IItem5W2HService serviceItem5W2H;
        private IItem5W2HService ServiceItem5W2H
        {
            get
            {
                if (serviceItem5W2H == null) serviceItem5W2H = new Item5W2HService(RepItem5W2H);
                return serviceItem5W2H;
            }

        }

        private IItem5W2HRepository repItem5W2H;
        private IItem5W2HRepository RepItem5W2H
        {
            get
            {
                if (repItem5W2H == null) repItem5W2H = new Item5W2HRepository(this.ISession);
                return repItem5W2H;
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
            return View(plans);
        }

        public ActionResult Create(string id)
        {
            Plan5W2H plan;
            if (id != null)
            {
                plan = ServicePlan5W2H.Get(new Guid(id.ToString()));
                return View(plan);
            }
            return View(new Plan5W2H());
        }

        [HttpPost]
        public ActionResult Create(Plan5W2H model, FormCollection form)
        {
            try
            {
                model.Start = Convert.ToDateTime(form["Start"], new CultureInfo("pt-BR"));
                model.End = Convert.ToDateTime(form["End"], new CultureInfo("pt-BR")); ;

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

        public ActionResult CreateItem(string id)
        {
            Item5W2H item;
            Plan5W2H plan = ServicePlan5W2H.Get(new Guid(id));
            item = new Item5W2H();
            item.Plan = plan;
            ICollection<Item5W2H> itens = plan.PlanItens;
            User usuario = ISession.QueryOver<User>().Where(x => x.Code == this.Usuario.Code).SingleOrDefault();
            ICollection<User> todosColoboradores = usuario.Friends;

            return View(new Item5W2HModel() { Item = item, Itens = itens, Colaboradores = todosColoboradores, Plan = plan });
        }

        [HttpPost]
        public ActionResult CreateItem(Item5W2HModel model, FormCollection form)
        {
            Plan5W2H plan = ServicePlan5W2H.Get(model.Plan.Code);

            string[] usuarios = form["Quem"].ToString().Split(',');
            foreach (string usuario in usuarios)
            {
                User selectedUser = ISession.QueryOver<User>()
                    .Where(x => x.Code == new Guid(usuario)).SingleOrDefault();
                model.Item.Quem.Add(selectedUser);
            }
            model.Item.Plan = plan;
            plan.PlanItens.Add(model.Item);

            return RedirectToAction("CreateItem", "Plan5W2H", new { @id = plan.Code.ToString() });
        }

        public ActionResult RemoveTask(string planId, string taskId)
        {

            Plan5W2H plan = ISession.QueryOver<Plan5W2H>()
                                    .Where(p => p.Code == new Guid(planId))
                                    .SingleOrDefault();

            plan.PlanItens.Remove(ServiceItem5W2H.Get(new Guid(taskId)));
            ISession.Update(plan);

            return RedirectToAction("CreateItem", "Plan5W2H", new { @id = planId });
        }
    }
}
