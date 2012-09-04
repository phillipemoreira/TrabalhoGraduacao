using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TG.Application.ActionFilter;

namespace TG.Application.Controllers
{
    [NHibernateActionFilter]
    public class Plan5W2HController : SessionController
    {
        //
        // GET: /Plan5W2H/

        public ActionResult Index()
        {
            return View();
        }

    }
}
