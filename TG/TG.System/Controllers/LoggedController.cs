using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    public class LoggedController : SessionController
    {

        public void AddUserAuthenticatedCookie(string dados)
        {
            FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(dados, false, 60);
            string encryptTicket = FormsAuthentication.Encrypt(authenticationTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            Response.Cookies.Add(authCookie);
        }

        public User GetUserAuthenticatedCookie()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                UserRepository repUser = new UserRepository(this.ISession);
                UserService serviceUser = new UserService(repUser);

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                return serviceUser.FindByCode(new Guid(identity.Name));
            }
            return null;
        }

        public void IncludUserViewBag()
        {
            ViewBag.Usuario = this.GetUserAuthenticatedCookie();
        }

    }
}
