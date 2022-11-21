using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ProductoFresco
    {
        public decimal Plu { get; set; }
        public decimal Peso { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        ProyectoMercadoEntities db = new ProyectoMercadoEntities();
        public bool Save()
        {
            try
            {
               
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public ProductoFresco consultar(int id)
        {
            var dato = db.PRODUCTOFRESCO.Find(id);

            ProductoFresco nuevo = new ProductoFresco
            {
                Plu = dato.PLU,
                Peso = dato.PESO,
                Descripcion = dato.DESCRIPCION,
                Precio = dato.PRECIO
            };

            return nuevo;
        }
    }

}