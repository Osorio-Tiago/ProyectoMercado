using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Caja
    {
        public decimal NumeroCaja { get; set; }

        ProyectoMercadoEntities db = new ProyectoMercadoEntities();
        public List<Caja> ListarCajas()
        {
            return this.db.CAJA.Select(caja => new Caja()
            {
                NumeroCaja = caja.NUMEROCAJA
            }).ToList();
        }
    }
}