using FluentValidation;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Validations
{
    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateDto>
    {
        public UsuarioUpdateValidator() 
        {
            RuleFor(i => i.Id).NotEqual(0).WithMessage("El id no puede ser 0");
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio.").MinimumLength(2).WithMessage("El nombre es muy corto.");
            RuleFor(n => n.UserName).NotEmpty().WithMessage("El usuario no puede estar vacio.").MinimumLength(2).WithMessage("El usuario es muy corto.");
            RuleFor(n => n.Apellido).NotEmpty().WithMessage("El nombre no puede estar vacio.").MinimumLength(2).WithMessage("El nombre es muy corto.");
            RuleFor(n => n.Gmail).NotEmpty().WithMessage("El gmail no puede estar vacio.").MinimumLength(2).WithMessage("El gmail es muy corto.")
            .Must(gmail => gmail.Contains("@gmail.com")).WithMessage("El correo electrónico debe ser de Gmail (@gmail.com).");
            RuleFor(n => n.Contraseña).NotEmpty().WithMessage("El nombre no puede estar vacio.").MinimumLength(6).WithMessage("El nombre es muy corto.");
        }
    }
}
