using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class DetalleFactura
    {
        public decimal NumeroFactura { get; set; }

        public decimal IdProductoFresco { get; set; }

        public string IdproductoNoFresco { get; set;}

        public decimal CantidadVenta { get; set; }

        public decimal Precio { get; set; }

        public Factura Factura { get; set;}
        public ProductoFresco ProductoFresco { get; set; }
        public ProductoNoFresco ProductoNoFresco { get; set; }
    }
}