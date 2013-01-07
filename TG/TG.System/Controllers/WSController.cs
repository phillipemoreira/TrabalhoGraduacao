using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    public class WSController : Controller
    {
        public ActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var obj = new { 
                    status = "ok",
                    var = "teste"
                };
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var obj = new { status = "error" };
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }
    }
}