using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    public abstract class SessionController : Controller
    {
        public ISession ISession { get; set; }

        public string Erro
        {
            get
            {
                return this.TempData["Erro"] as string;
            }

            set
            {
                this.TempData["Erro"] = value;

            }

        }

    }
}
