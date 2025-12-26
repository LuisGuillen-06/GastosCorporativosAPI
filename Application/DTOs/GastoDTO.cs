using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GastoDTO
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public decimal Monto { get; set; }

        public EstadoGasto Estado { get; set; }

        public Guid EmpleadoId { get; set; }
    }
}
