using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [EndpointSummary("Obtiene la lista de todos los empleados")]
        [EndpointDescription("Este endpoint devuelve todos los empleados activos en la base de datos. Requiere API Key.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ObtenerTodos()
        {
            var empleados = await _repository.GetAllAsync();

            return Ok(empleados);
        }


        [HttpPost]
        [EndpointSummary("Crea un nuevo empleado")]
        [EndpointDescription("Valida los datos y guarda un nuevo empleado. El Email debe ser único.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Crear([FromBody] CreateEmpleadoDTO empleadoDTO)
        {

            var nuevoEmpleado = new Empleado(

                empleadoDTO.Nombre,
                empleadoDTO.Apellido,
                empleadoDTO.Email
                );

            await _repository.AddAsync(nuevoEmpleado);

            return Ok(new { message = $"El Empleado {nuevoEmpleado.Id} se ha creado con exito" });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Actualizar(Guid id, [FromBody] CreateEmpleadoDTO empleadoDTO)
        {
            var empleadoExistente = await _repository.GetByIdAsync(id);

            if (empleadoExistente == null)
            {
                return NotFound($"No se encontro al empleado con el {id}");
            }

            empleadoExistente.Nombre = empleadoDTO.Nombre;
            empleadoExistente.Apellido = empleadoDTO.Apellido;
            empleadoExistente.Email = empleadoDTO.Email;

            await _repository.UpdateAsync(empleadoExistente);

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Eliminar(Guid id)
        {
            var empleadoDelte = await _repository.GetByIdAsync(id);

            if (empleadoDelte == null)
            {
                return NotFound($"No existe el Empleado con el id {id} para eliminarlo");
            }

            await _repository.DeleteAsync(empleadoDelte);

            return NoContent();
        }
    }
}
