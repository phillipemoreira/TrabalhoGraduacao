using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TG.Application.Controllers
{
    public class WSController : Controller
    {
        public ActionResult Login(string username, string password)
        {
            var obj = new { var = "teste" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}