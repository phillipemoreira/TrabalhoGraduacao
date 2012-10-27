using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TG.Application.ActionFilter;

namespace TG.Application.Controllers
{
    [NHibernateActionFilter]
    [Authorize]
    public class HomeController : SessionController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
