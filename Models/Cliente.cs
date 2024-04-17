using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationExamen.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(5)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}