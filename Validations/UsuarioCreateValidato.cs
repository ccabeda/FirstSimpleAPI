using FluentValidation;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Validations
{
    public class UsuarioCreateValidator : AbstractValidator<UsuarioCreateDto>
    {
        public UsuarioCreateValidator() 
        {
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio.").MinimumLength(2).WithMessage("El nombre es muy corto.");
            RuleFor(n => n.UserName).NotEmpty().WithMessage("El usuario no puede estar vacio.").MinimumLength(2).WithMessage("El usuario es muy corto.");
            RuleFor(n => n.Apellido).NotEmpty().WithMessage("El apellido no puede estar vacio.").MinimumLength(2).WithMessage("El apellido es muy corto.");
            RuleFor(n => n.Gmail).NotEmpty().WithMessage("El gmail no puede estar vacio.").MinimumLength(2).WithMessage("El gmail es muy corto.")
            .Must(gmail => gmail.Contains("@gmail.com")).WithMessage("El correo electrónico debe ser de Gmail (@gmail.com).");
            RuleFor(n => n.Contraseña).NotEmpty().WithMessage("La contraseña no puede estar vacio.").MinimumLength(6).WithMessage("La contraseña es muy corto.");
        }
    }
}
