using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter]
    [Authorize]
    public class HomeController : LoggedController
    {
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            this.IncludUserViewBag();
            return View();
        }

    }
}
