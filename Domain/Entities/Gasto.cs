using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Gasto
    {
        public Guid Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public decimal Monto { get; set; }

        public EstadoGasto Estado { get; set; } = EstadoGasto.Borrador;

        public Guid EmpleadoId { get; set; }

        public virtual Empleado? Empleado { get; set; }

        public Gasto(DateTime fecha, string descripcion, decimal monto, Guid empleadoId)
        {
            Id = Guid.NewGuid();
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
            EmpleadoId = empleadoId;

        }

        public Gasto() { }
    }
}
