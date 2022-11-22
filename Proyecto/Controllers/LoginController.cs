using Oracle.ManagedDataAccess.Client;
using Proyecto.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            if (IsValid(user))
            {
                if(user.Rol == "CAJERO")
                {
                    return RedirectToAction("Index", "Ventas");
                }
                else if (user.Rol == "SISTEMAS")
                {
                    return RedirectToAction("Consultar", "TI", user);
                }
                else if(user.Rol == "GERENTEGENERAL")
                {
                    return RedirectToAction("Consultar", "GerenteGeneral", user);
                }
                else
                {
                    return RedirectToAction("Consultar", "GerenteArea");
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        OracleConnection conn = new OracleConnection("DATA SOURCE = localhost:1522/xe ; PASSWORD = mercado ; USER ID = MERCADO");
        private bool IsValid(Usuario user)
        {
            try
            {
                string connectionString = "DATA SOURCE = localhost:1522 / xe; PASSWORD = :password; USER ID = :user";

                connectionString = connectionString.Replace(":password", user.Password);
                connectionString = connectionString.Replace(":user", user.Username);
                OracleConnection conn2 = new OracleConnection(connectionString);

                conn2.Open();

                if(conn2.State != System.Data.ConnectionState.Closed)
                {
                    conn.Open();

                    string consulta = "select GRANTED_ROLE from dba_role_privs where grantee = upper('" + user.Username + "') and (GRANTED_ROLE = 'SISTEMAS' OR GRANTED_ROLE = 'GERENTEAREACUIDADOPERSONAL' OR GRANTED_ROLE = 'GERENTEAREAMERCANCIA' OR GRANTED_ROLE = 'GERENTEGENERAL' OR GRANTED_ROLE = 'CAJERO' OR GRANTED_ROLE = 'GERENTEAREAFRESCOS' OR GRANTED_ROLE = 'GERENTEAREAABARROTES')";

                    OracleCommand comando = new OracleCommand(consulta, conn);

                   OracleDataReader lector = comando.ExecuteReader();

                    if (lector.Read()){
                        user.Rol = (string)lector["granted_role"].ToString();
                        return true;
                    }      
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}