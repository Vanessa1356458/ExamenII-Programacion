using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationExamen.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal Total { get; set; }

    }
}