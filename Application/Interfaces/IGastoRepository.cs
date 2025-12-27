using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGastoRepository
    {
        Task AddAsync(Gasto gasto);

        Task UpdateAsync(Gasto gasto);

        Task DeleteAsync(Gasto gasto);

        Task<IEnumerable<Gasto>> GetAllAsync();

        Task<Gasto?> GetByIdAsync(Guid id);


    }
}
