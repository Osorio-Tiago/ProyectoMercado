using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ProductoNoFresco
    {
        public string Ean { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Area { get; set; }
        public decimal Precio { get; set; }
      
    }
}