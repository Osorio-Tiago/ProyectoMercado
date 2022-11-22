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
        static Usuario userSession = null;

        [HttpGet]
        public ActionResult Consultar(Usuario user)
        {
            if(userSession == null && user != null)
            {
                userSession = user;
            }
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

        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Bitacora()
        {
            string resultado = "";
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
               
                string consulta = "select * FROM DBA_AUDIT_TRAIL where owner = 'MERCADO'";
                OracleCommand comando = new OracleCommand(consulta, conn);
                OracleDataReader reader = comando.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                       resultado += "USUARIO = "+ reader.GetString(1) + " \n";
                       resultado += "TABLA AFECTADA = " + reader.GetString(6)+ " \n";
                       resultado += "ACCION = " + reader.GetString(8)+ " \n";
                       resultado += "HORA = " + reader.GetString(31) + " \n";
                       resultado += "VALORES ENVIADOS = " + reader.GetString(39) + "]\n\n\n";
                       
                    }
                }
                finally
                {
                    // always call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest));
                throw;
            }

            ViewBag.bitcoras = resultado;
            return View();
        }

        [HttpPost]
        public ActionResult TI_InsertarProductoNoFresco(ProductoNoFresco productoNoFresco)
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
        public ActionResult TI_InsertarProductoFresco(ProductoFresco productoFresco)
        {

            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
                string consulta = "insert into mercado.ProductoFresco(PLU, peso, descripcion, precio) values (" + productoFresco.Plu+","+ productoFresco.Peso+",'"+ productoFresco.Descripcion+"',"+productoFresco.Precio+")";
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
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
                string consulta = "update mercado.ProductoFresco set peso = " + productoFresco.Peso+", descripcion = '"+productoFresco.Descripcion+"', precio = "+productoFresco.Precio+"where PLU = "+productoFresco.Plu;
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
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();
        
                string consulta = "update mercado.ProductoNoFresco set descripcion = " + productoNoFresco.Descripcion+", precio = "+productoNoFresco.Precio+", cantidad = "+productoNoFresco.Cantidad+", area = "+productoNoFresco.Area+"where EAN = "+productoNoFresco.Ean; ;
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
        public ActionResult ConsultarProductoFresco()
        {
            return View();
        }


        [HttpPost]
        public ActionResult TI_EliminarProductoFresco(ProductoFresco productoFresco)
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
        public ActionResult TI_EliminarProductoNoFresco(ProductoNoFresco productoNoFresco)
        {
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = " + userSession.Password + " ; USER ID = " + userSession.Username);
                conn.Open();

                string consulta = "Delete mercado.ProductoNoFresco where EAN = '" + productoNoFresco.Ean+"'";
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