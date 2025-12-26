using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public bool EsAprobador { get; set; }

        public Empleado(string nombre, string apellido, string email)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            EsAprobador = false;
        }

        public Empleado() { }
    }
}
