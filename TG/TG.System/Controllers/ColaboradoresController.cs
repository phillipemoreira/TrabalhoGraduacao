using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Application.Models;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using System;
using System.Collections;
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
        private IService<User> serviceUser;
        private IService<User> ServiceUser
        {
            get
            {
                if (serviceUser == null) serviceUser = new Service<User>(RepUser);

                return serviceUser;
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

        private IService<Invite> serviceInvite;
        private IService<Invite> ServiceInvite
        {
            get
            {
                if (serviceInvite == null) serviceInvite = new Service<Invite>(RepInvite);

                return serviceInvite;
            }

        }

        private IRepository<Invite> repInvite;
        private IRepository<Invite> RepInvite
        {
            get
            {
                if (repInvite == null) repInvite = new Repository<Invite>(this.ISession);

                return repInvite;
            }

        }

        public ActionResult Index()
        {
            IList<User> colaboradores = ISession.QueryOver<User>().Where(x => x.Code != this.Usuario.Code).List();
            IList<Invite> convidadosPorMim = ISession.QueryOver<Invite>().Where(x => x.De.Code == this.Usuario.Code).List();
            IList<Invite> estaoMeConvidando = ISession.QueryOver<Invite>().Where(x => x.Para.Code == this.Usuario.Code).List();

            IEnumerable<User> users = colaboradores.Except(convidadosPorMim.Select(c => c.Para).AsEnumerable<User>());
            
            return View(new ColaboradoresModel()
            {
                Colaboradores = users,
                ConvidadosPorMim = convidadosPorMim,
                EstaoMeConvidando = estaoMeConvidando
            });
        }

        [HttpPost]
        public ActionResult SalvarColaboradores(FormCollection form)
        {
            string[] usuariosConvidados = form["Colaboradores"].Split(',');
            string mensagem = form["mensagem"].ToString();

            foreach (string usuarioId in usuariosConvidados)
            {
                User usuario = ServiceUser.Get(new Guid(usuarioId));
                Invite convite = new Invite() {De = this.Usuario , Para = usuario, Message = mensagem};
                ServiceInvite.Save(convite);
            }

            ViewBag.Message = "SUCCESS";
            return RedirectToAction("Index");
        }

        public ActionResult Aceitar(string convite, string id)
        {
            User usuario = ServiceUser.Get(new Guid(id));
            Invite invite = ServiceInvite.Get(new Guid(convite));
            invite.Aceito = Invite.SatusConvite.Aceito;

            this.Usuario.Friends.Add(usuario);

            ISession.Merge(this.Usuario);
            ServiceInvite.SaveOrUpdate(invite);

            ViewBag.Message = "SUCCESS";
            return RedirectToAction("Index");
        }

        public ActionResult Rejeitar(string convite)
        {
            Invite invite = ServiceInvite.Get(new Guid(convite));
            invite.Aceito = Invite.SatusConvite.Rejeitado;
            ServiceInvite.SaveOrUpdate(invite);

            ViewBag.Message = "SUCCESS";
            return RedirectToAction("Index");
        }
    }
}
