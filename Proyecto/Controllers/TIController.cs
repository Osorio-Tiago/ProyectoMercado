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
        OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = mercado ; USER ID = MERCADO");

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


      
        [HttpPost]
        public ActionResult TI_InsertarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {

            try
            {
                conn.Open();
                productoNoFresco.Area = "Abarrotes";
                string consulta = "insert into ProductoNoFresco(EAN, descripcion, cantidad, precio, area) values ('" + productoNoFresco.Ean + "','" + productoNoFresco.Descripcion + "'," + productoNoFresco.Cantidad + "," + productoNoFresco.Precio + ",'" + productoNoFresco.Area + "')";
                OracleCommand comando = new OracleCommand(consulta, conn);

                comando.ExecuteNonQuery();

                return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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

                return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        public ActionResult TI_ActualizarProductoFresco(ProductoFresco productoFresco)
        {
            try
            {
                conn.Open();
                string consulta = "";
                OracleCommand comando = new OracleCommand(consulta, conn);

                comando.ExecuteNonQuery();

                return new HttpStatusCodeResult(HttpStatusCode.OK, "OK");
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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