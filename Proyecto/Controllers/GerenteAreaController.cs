using Oracle.ManagedDataAccess.Client;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = mercado ; USER ID = MERCADO");

        [HttpPost]
        public ActionResult GerenteArea_ModificarProductoFresco(ProductoFresco productoFresco)
        {
            try
            {
                conn.Open();
                string consulta = "update ProductoFresco set peso = " + productoFresco.Peso + ", descripcion = '" + productoFresco.Descripcion + "', precio = " + productoFresco.Precio + "where PLU = " + productoFresco.Plu;
                OracleCommand comando = new OracleCommand(consulta, conn);

                comando.ExecuteNonQuery();

                return Json(new HttpStatusCodeResult(HttpStatusCode.OK, "OK"));
            }
            catch (Exception e)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }
        }

        [HttpPost]
        public ActionResult GerenteArea_ModificarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {
            try
            {
                conn.Open();
        
                string consulta = "update ProductoNoFresco set descripcion = " + productoNoFresco.Descripcion + ", precio = " + productoNoFresco.Precio + ", cantidad = " + productoNoFresco.Cantidad + ", area = " + productoNoFresco.Area + "where EAN = " + productoNoFresco.Ean; ;
                OracleCommand comando = new OracleCommand(consulta, conn);

                comando.ExecuteNonQuery();

                return Json(new HttpStatusCodeResult(HttpStatusCode.OK, "OK"));
            }
            catch (Exception e)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }
        }

    }
}