using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<Empleado?> GetByIdAsync(Guid id);

        Task<IEnumerable<Empleado>> GetAllAsync();

        Task AddAsync(Empleado empleado);

        Task UpdateAsync(Empleado empleado);

        Task DeleteAsync(Empleado empleado);


    }
}
