using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationExamen.Models
{
    public class FacturaDetalle
    {
        [Key]
        public int FacturaDetalleId { get; set; }

        [ForeignKey("Factura")]
        public int FacturaId { get; set; }

        [ForeignKey("Servicio")]
        public int ServicioId { get; set; }

        public Factura Factura { get; set; }

        public Servicio Servicio { get; set; }

        public decimal Precio { get; set; }
        public int Cantidad { get; set; } 
        public decimal ISV { get; set; }
        public decimal TotalLinea { get; set; }

    }
}