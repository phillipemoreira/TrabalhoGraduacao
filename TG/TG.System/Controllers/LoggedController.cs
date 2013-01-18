using Plan5W2HPlusPlus.Application.Models;
using Plan5W2HPlusPlus.Application.Util;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using Plan5W2HPlusPlus.Model.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    public class LoggedController : SessionController
    {

        private User usuario;

        public User Usuario
        {

            get
            {
                if (usuario == null)
                {
                    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {
                        UserRepository repUser = new UserRepository(this.ISession);
                        UserService serviceUser = new UserService(repUser);

                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        var identity = new GenericIdentity(authTicket.Name, "Forms");
                        usuario = serviceUser.FindByCode(new Guid(identity.Name));
                    }
                }

                return usuario;
            }
        }

        public void AddUserAuthenticatedCookie(string dados)
        {
            FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(dados, false, 60);
            string encryptTicket = FormsAuthentication.Encrypt(authenticationTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            Response.Cookies.Add(authCookie);
        }

        public string GetUserIDAuthenticatedCookie()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                UserRepository repUser = new UserRepository(this.ISession);
                UserService serviceUser = new UserService(repUser);

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                return identity.Name;
            }
            return null;
        }

        public void IncludUserViewBag()
        {
            String urlavatar;
            if(this.Usuario != null)
                urlavatar = GetAvatarUrl(this.Usuario.Code.ToString());
            else
                urlavatar = GetGenericAvatar();

            ViewBag.UserModel = new UserModel() { Usuario = this.Usuario, UrlAvatar = urlavatar };
        }

        public String GetAvatarUrl(String id)
        {
            string filePath = Server.MapPath(Url.Content("~/Content/UsersAvatar/avatar-" + id + ".png"));
            if (Tools.FileExists(filePath))
                return Url.Content("~/Content/UsersAvatar/avatar-" + id + ".png");
            return GetGenericAvatar();
        }

        public String GetGenericAvatar()
        {
            return Url.Content("~/Content/UsersAvatar/avatar.png");
        }
    }
}
