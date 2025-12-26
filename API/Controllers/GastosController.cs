using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [ApiController]: Le dice a .NET que esto es una API (mejora los errores y validaciones).
    // [Route]: Define la URL. Será "tudominio.com/api/gastos"

    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly IGastoRepository _repositroy;

        // INYECCIÓN DE DEPENDENCIAS
        // Pedimos el repositorio. No sabemos si es SQL Server, Oracle o un archivo de texto.
        // Solo sabemos que cumple con IGastoRepository.

        public GastosController(IGastoRepository repositroy)
        { 
            _repositroy = repositroy;
        }

        // 1. GET: api/gastos
        // Obtiene la lista completa

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var gastos = await _repositroy.GetAllAsync();

            var gastoDTO = gastos.Select(g => new GastoDTO
            {
                Id = g.Id,
                Fecha = g.Fecha,
                Descripcion = g.Descripcion,
                Monto = g.Monto,
                Estado = g.Estado,
                EmpleadoId = g.EmpleadoId
            });
            return Ok(gastoDTO);
        }

        // 2. POST: api/gastos
        // Guarda un nuevo gasto

        [HttpPost]

        public async Task<IActionResult> Crear([FromBody] CreateGastoDTO gastoDTO)
        {
            if (gastoDTO.Monto <= 0)
                return BadRequest("El monto debe ser mayor a 0");

            var nuevoGasto = new Gasto(
                
                gastoDTO.Fecha,
                gastoDTO.Descripcion,
                gastoDTO.Monto,
                gastoDTO.EmpleadoId
                
                );

            await _repositroy.AddAsync(nuevoGasto);

            return Ok(new { message = $"El gasto {nuevoGasto.Id } se ha creado con exito"  });
        }
    }
}
