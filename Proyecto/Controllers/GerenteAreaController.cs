using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class GerenteAreaController : Controller
    {
        // GET: GerenteArea
        public ActionResult Consultar()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Modificar()
        {
            return View();
        }
    }
}