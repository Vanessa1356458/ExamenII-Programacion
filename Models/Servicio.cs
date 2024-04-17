using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationExamen.Models
{
    public class Servicio
    {
        [Key]
        public int ServicioId { get; set; }

        [Required]
        [StringLength(5)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(25)]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

    }
}