using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        /*
        ProyectoMercadoEntities db = new ProyectoMercadoEntities();
        public bool AutenticarUsuario()
        {
            string query = "select username from dba_users where username = 'username'";
            

        }
        */
    }
}