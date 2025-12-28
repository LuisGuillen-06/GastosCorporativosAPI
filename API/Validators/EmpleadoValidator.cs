using FluentValidation;
using Application.DTOs;
using Infrastructure.Persistence;

namespace API.Validators
{
    public class EmpleadoValidator : AbstractValidator<CreateEmpleadoDTO>
    {
        private readonly ApplicationDbContext _context;
        public EmpleadoValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacio");

            RuleFor(e => e.Apellido)
                .NotEmpty().WithMessage("El Apellido no puede estar vacio");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("El Email no puede estar vacio")
                .EmailAddress().WithMessage("El formato del email no es válido (usuario@dominio.com)")
                .Must((e,email) =>
                {
                    bool existe = _context.Empleados.Any(e => e.Email == email);
                    return !existe;
                })
                .WithMessage("Este correo electrónico ya está registrado en el sistema");
        }
    }
}
