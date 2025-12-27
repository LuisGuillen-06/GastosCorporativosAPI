using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly ApplicationDbContext _context;

        public GastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Gasto gasto)
        {
            await _context.Gastos.AddAsync(gasto);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Gasto gasto)
        {
            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Gasto>> GetAllAsync()
        {
            // .AsNoTracking() es un truco PRO
            // Hace que la consulta sea más rápida si solo vamos a leer datos (no modificarlos).
            // .Include(g => g.Empleado) es un "JOIN" de SQL. Trae los datos del dueño del gasto también.

            return await _context.Gastos
                .Include(g => g.Empleado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Gasto?> GetByIdAsync(Guid id)
        {
            return await _context.Gastos
                .Include(g => g.Empleado)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateAsync(Gasto gasto)
        {
            _context.Entry(gasto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
