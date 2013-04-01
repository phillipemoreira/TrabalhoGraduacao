using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Models;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter(Order = 1)]
    [AuthorizationActionFilter(Order = 2)]
    [Authorize]
    public class HomeController : LoggedController
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

        [Authorize]
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

            return View(plans);
        }

    }
}
