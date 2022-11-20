using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Factura
    {
        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public decimal IdCaja { get; set; }

        public decimal IdUsuario { get; set; }

        public Caja Caja { get; set;}
    }
}