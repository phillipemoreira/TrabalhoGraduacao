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

            foreach(Plan5W2H plan in plans)
            {
                var values = plan.GetItensByUser(this.Usuario);
            }

            return View(new TaskModel() { Plans = plans });
        }

    }
}
