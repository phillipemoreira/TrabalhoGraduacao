using Plan5W2HPlusPlus.Application.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter(Order = 1)]
    [AuthorizationActionFilter(Order = 2)]
    [Authorize]
    public class ComunicacaoController : LoggedController
    {   
        public ActionResult Index()
        {
            return View();
        }

    }
}
