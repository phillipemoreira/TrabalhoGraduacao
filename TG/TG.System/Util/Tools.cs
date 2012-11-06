using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TG.Application.Util
{
    public class Tools
    {
        public static String retrieveUserFromCookie(TG.Application.MvcApplication app)
        {
            if (app.User.Identity.IsAuthenticated)
            {
                HttpCookie cookie = app.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            return null;
        }
    }
}