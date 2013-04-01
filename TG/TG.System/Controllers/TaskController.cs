using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Application.Models;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter(Order = 1)]
    [AuthorizationActionFilter(Order = 2)]
    [Authorize]
    public class TaskController : LoggedController
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

        public ActionResult Index()
        {
            ICollection<Plan5W2H> plans = ISession.QueryOver<Plan5W2H>()
                    .JoinQueryOver<Item5W2H>(p => p.PlanItens)
                        .JoinQueryOver<User>(i => i.Quem)
                        .Where(u => u.Code == this.Usuario.Code)
                        .List()
                        .Distinct()
                        .OrderBy(p => p.Creation)
                        .ToList();

            return View(new TaskModel() { Plans = plans });
        }

        public ActionResult ConcluirTask(String taskId)
        {
            Item5W2H item = ISession.QueryOver<Item5W2H>()
                                .Where(p => p.Code == new Guid(taskId)).SingleOrDefault();
            item.Andamento = Status.Finalizado;

            return RedirectToAction("Index");
        }

        public ActionResult PararTask(String taskId)
        {
            Item5W2H item = ISession.QueryOver<Item5W2H>()
                                .Where(p => p.Code == new Guid(taskId)).SingleOrDefault();
            item.Andamento = Status.Parado;

            return RedirectToAction("Index");
        }

        public ActionResult ContinuarTask(String taskId)
        {
            Item5W2H item = ISession.QueryOver<Item5W2H>()
                                .Where(p => p.Code == new Guid(taskId)).SingleOrDefault();
            item.Andamento = Status.EmAndamento;

            return RedirectToAction("Index");
        }
    }
}
