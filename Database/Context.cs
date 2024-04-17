using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationExamen.Database
{
    public class Context:DbContext
    {
        public Context():base("name=Facturacion")
        {
            
        }

        public System.Data.Entity.DbSet<WebApplicationExamen.Models.Factura> Facturas { get; set; }

        public System.Data.Entity.DbSet<WebApplicationExamen.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebApplicationExamen.Models.FacturaDetalle> FacturaDetalles { get; set; }

        public System.Data.Entity.DbSet<WebApplicationExamen.Models.Servicio> Servicios { get; set; }
    }
}