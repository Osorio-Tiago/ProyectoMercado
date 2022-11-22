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
    
    public class GerenteGeneralController : Controller
    {
        static Usuario userSession = null;

        [HttpGet]
        public ActionResult Consultar(Usuario user)
        {
            if (userSession == null && user != null)
            {
                userSession = user;
            }
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

        [HttpPost]
        public ActionResult GerenteGeneral_InsertarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {

            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();

                string consulta = "insert into mercado.ProductoNoFresco(EAN, descripcion, cantidad, precio, area) values ('" + productoNoFresco.Ean + "','" + productoNoFresco.Descripcion + "'," + productoNoFresco.Cantidad + "," + productoNoFresco.Precio + ",'" + productoNoFresco.Area + "')";
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
        public ActionResult GerenteGeneral_InsertarProductoFresco(ProductoFresco productoFresco)
        {

            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
                string consulta = "insert into mercado.ProductoFresco(PLU, peso, descripcion, precio) values (" + productoFresco.Plu + "," + productoFresco.Peso + ",'" + productoFresco.Descripcion + "'," + productoFresco.Precio + ")";
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
        public ActionResult GerenteGeneral_ModificarProductoFresco(ProductoFresco productoFresco)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
                string consulta = "update mercado.ProductoFresco set peso = " + productoFresco.Peso + ", descripcion = '" + productoFresco.Descripcion + "', precio = " + productoFresco.Precio + "where PLU = " + productoFresco.Plu;
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
        public ActionResult GerenteGeneral_ModificarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();

                string consulta = "update mercado.ProductoNoFresco set descripcion = '" + productoNoFresco.Descripcion + "', precio = " + productoNoFresco.Precio + ", cantidad = " + productoNoFresco.Cantidad + ", area = '" + productoNoFresco.Area + "' where EAN = '" + productoNoFresco.Ean+"'";
                OracleCommand comando = new OracleCommand(consulta, conn);

                comando.ExecuteNonQuery();

                return Json(new HttpStatusCodeResult(HttpStatusCode.OK, "OK"));
            }
            catch (Exception e)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest));
            }
        }


        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GerenteGeneral_EliminarProductoFresco(ProductoFresco productoFresco)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
                string consulta = "Delete mercado.ProductoFresco where PLU = " + productoFresco.Plu;
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
        public ActionResult GerenteGeneral_EliminarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();

                string consulta = "Delete mercado.ProductoNoFresco where EAN = '" + productoNoFresco.Ean + "'";
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