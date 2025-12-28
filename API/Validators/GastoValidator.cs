using FluentValidation;
using Application.DTOs;
using System.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Validators
{
    public class GastoValidator : AbstractValidator<CreateGastoDTO>
    {
        private readonly ApplicationDbContext _context;
        public GastoValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Fecha)
                 .NotEmpty().WithMessage("La fecha es obligatoria")
                 .LessThanOrEqualTo(DateTime.Now).WithMessage("No puedes registrar gastos futuros");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción no puede estar vacía")
                .Length(5, 100).WithMessage("La descripción debe tener entre 5 y 100 letras");

            RuleFor(x => x.Monto)
                .NotEmpty()
                .InclusiveBetween(0.01m, 9999999m).WithMessage("El monto debe ser mayor a 0 y menor a 10 millones");

            RuleFor(x => x.EmpleadoId)
                .Must(id =>
                {
                    bool existe = _context.Empleados.Any(e => e.Id == id);
                    return existe;
                })
                .WithMessage("El empleado especificado no existe en nuestra base de datos.");
        }
    }
}
