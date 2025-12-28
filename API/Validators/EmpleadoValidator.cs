using FluentValidation;
using Application.DTOs;

namespace API.Validators
{
    public class EmpleadoValidator : AbstractValidator<CreateEmpleadoDTO>
    {
        public EmpleadoValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El Nombre no puede estar vacio");

            RuleFor(e => e.Apellido)
                .NotEmpty().WithMessage("El Apellido no puede estar vacio");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("El Email no puede estar vacio")
                .EmailAddress().WithMessage("El formato del email no es válido (usuario@dominio.com)");
        }
    }
}
