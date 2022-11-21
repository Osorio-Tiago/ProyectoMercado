using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Usuario user)
        {

            if (isValid(user))
            {
                return RedirectToAction("Consultar","GerenteArea");
            }
            return View(user);
        }

        private bool isValid(Usuario user)
        {
            if (user.Username == "123" && user.Password == "123")
                return true;
            return false;
        }
    }
}