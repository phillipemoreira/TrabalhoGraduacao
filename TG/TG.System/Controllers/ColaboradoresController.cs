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
    public class ColaboradoresController : LoggedController
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

        public ActionResult Index()
        {
            IList<User> colaboradores = ISession.QueryOver<User>().Where(x => x.Code != this.Usuario.Code).List();
            IList<Invite> convidadosPorMim = ISession.QueryOver<Invite>().Where(x => x.De.Code == this.Usuario.Code).List();
            IList<Invite> estaoMeConvidando = ISession.QueryOver<Invite>().Where(x => x.Para.Code == this.Usuario.Code).List();

            return View(new ColaboradoresModel()
            {
                Colaboradores = colaboradores,
                ConvidadosPorMim = convidadosPorMim,
                EstaoMeConvidando = estaoMeConvidando
            });
        }

        [HttpPost]
        public ActionResult SalvarColaboradores(Guid id, FormCollection form)
        {
            return Json();
        }
    }
}
