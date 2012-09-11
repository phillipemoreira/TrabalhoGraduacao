using System.Web.Mvc;
using TG.Application.Models;
using TG.Model.Services;
using TG.Model.Models;
using TG.Model.Repository;
using System.Web.Security;
using TG.Application.ActionFilter;

namespace TG.Application.Controllers
{
    [NHibernateActionFilter]
    public class AutenticationController : SessionController
    {
        private IUserService service;
        private IUserService Service
        {
            get
            {
                if (service == null) service = new UserService(RepUser);

                return service;
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
        // GET: /Autentication/

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                User user = Service.FindByUsernamePassword(model.UserName, model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Code.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
