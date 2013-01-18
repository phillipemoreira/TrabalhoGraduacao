using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plan5W2HPlusPlus.Application.ActionFilter;
using Plan5W2HPlusPlus.Model.Services;
using Plan5W2HPlusPlus.Model.Models;
using Plan5W2HPlusPlus.Model.Repository;
using System.IO;
using System.Drawing;
using Plan5W2HPlusPlus.Application.Util;

namespace Plan5W2HPlusPlus.Application.Controllers
{
    [NHibernateActionFilter]
    public class UserController : LoggedController
    {
        private IService<User> service;
        private IService<User> Service
        {
            get
            {
                if (service == null) service = new Service<User>(RepUser);

                return service;
            }

        }

        private IRepository<User> repUser;
        private IRepository<User> RepUser
        {
            get
            {
                if (repUser == null) repUser = new Repository<User>(this.ISession);

                return repUser;
            }

        }
        
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            User usuario = this.Usuario;
            this.IncludUserViewBag();
            if(usuario != null)
                return View(usuario);
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User usuario, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    Image avatar = Image.FromStream(file.InputStream, true, true);

                    avatar = Tools.CropImageToSquare(avatar);
                    avatar = Tools.ResizeImage(avatar, 60, 60);

                    var fileName = "avatar-" + usuario.Code.ToString() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/UsersAvatar"), fileName);
                    avatar.Save(path);
                }
                User userSession = this.Usuario;
                if (userSession != null)
                {
                    usuario = Service.Get(usuario.Code);
                    TryUpdateModel(usuario);
                }
                else
                {
                    if(Service.Get(usuario.Code) == null)
                        Service.Save(usuario);
                }
                
                ViewBag.Message = "SUCCESS";
                this.IncludUserViewBag();
                return View(usuario);
            }
            catch
            {
                ViewBag.Message = "ERROR";
                this.IncludUserViewBag();
                return View(usuario);
            }
        }
    }
}
