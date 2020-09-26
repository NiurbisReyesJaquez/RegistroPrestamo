using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos_Personas.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamosId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introducir la fecha del prestamo")]
        public DateTime Fecha { get; set; } = DateTime.Today;
        [Required(ErrorMessage = "Es oblitario seleccionar la identificacion de la Persona!")]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Es oblitario seleccionar el Concepto de dicho prestamo!")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Es oblitario introducir el Monto a realizar el prestamo!")]
        public float Monto { get; set; }
        public float Balance { get; set; }

    }
}
