using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.Models;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System.Web.Security;
using Plan5W2HPlusPlus.Application.ActionFilter;
using System.Web;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter]
    public class AutenticationController : LoggedController
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
                    var obj = new { status = "ok" };

                    this.AddUserAuthenticatedCookie(user.Code.ToString());
                    
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var obj = new { status = "error" };
                    return Json(obj, JsonRequestBehavior.DenyGet);
                }
            }
            catch
            {
                var obj = new { status = "error" };
                return Json(obj, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
