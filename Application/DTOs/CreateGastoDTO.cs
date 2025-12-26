using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateGastoDTO
    {
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripción no puede estar vacía")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 100 letras")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 9999999, ErrorMessage = "El monto debe ser mayor a 0 y menor a 10 millones")]
        public decimal Monto { get; set; }

        [Required]
        public Guid EmpleadoId { get; set; }
    }
}
