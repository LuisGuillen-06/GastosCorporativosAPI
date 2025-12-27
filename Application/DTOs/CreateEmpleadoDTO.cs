using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateEmpleadoDTO
    {
        [Required (ErrorMessage ="Debes Ingresar el Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debes Ingresar el Apellido")]

        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debes Ingresar el Email")]
        [EmailAddress(ErrorMessage ="El formato del correo no es valido")]
        public string Email { get; set; } = string.Empty;
    }
}
