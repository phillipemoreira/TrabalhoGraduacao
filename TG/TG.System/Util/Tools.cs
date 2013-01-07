using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Plan5W2HPlusPlus.Application.Util
{
    public class Tools
    {
        public static String retrieveUserFromCookie(Plan5W2HPlusPlus.Application.MvcApplication app)
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