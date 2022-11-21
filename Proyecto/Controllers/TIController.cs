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
    public class TIController : Controller
    {
      

        [HttpGet]
        public ActionResult Consultar()
        {
            return View();
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


        OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = mercado ; USER ID = MERCADO");
        [HttpPost]
        public ActionResult TI_InsertarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {

            try
            {
                conn.Open();
              
                string consulta = "insert into ProductoNoFresco(EAN, descripcion, cantidad, precio, area) values ('" + productoNoFresco.Ean + "','" + productoNoFresco.Descripcion + "'," + productoNoFresco.Cantidad + "," + productoNoFresco.Precio + ",'" + productoNoFresco.Area + "')";
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
        public ActionResult TI_InsertarProductoFresco(ProductoFresco productoFresco)
        {

            try
            {
                conn.Open();
                string consulta = "insert into ProductoFresco(PLU, peso, descripcion, precio) values ("+ productoFresco.Plu+","+ productoFresco.Peso+",'"+ productoFresco.Descripcion+"',"+productoFresco.Precio+")";
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
        public ActionResult TI_ModificarProductoFresco(ProductoFresco productoFresco)
        {
            try
            {
                conn.Open();
                string consulta = "update ProductoFresco set peso = "+productoFresco.Peso+", descripcion = '"+productoFresco.Descripcion+"', precio = "+productoFresco.Precio+"where PLU = "+productoFresco.Plu;
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
        public ActionResult TI_ModificarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {
            try
            {
                conn.Open();
        
                string consulta = "update ProductoNoFresco set descripcion = "+productoNoFresco.Descripcion+", precio = "+productoNoFresco.Precio+", cantidad = "+productoNoFresco.Cantidad+", area = "+productoNoFresco.Area+"where EAN = "+productoNoFresco.Ean; ;
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

        [HttpGet]
        public ActionResult Bitacora()
        {
            return View();
        }
    }
}