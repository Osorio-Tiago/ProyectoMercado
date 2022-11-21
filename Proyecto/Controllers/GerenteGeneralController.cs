using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class GerenteGeneralController : Controller
    {
        [HttpGet]
        public ActionResult Consultar()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Consultar_ProductoFresco(int id)
        {
            ProductoFresco aux = new ProductoFresco();
            return Json(aux, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Modificar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }
    }
}