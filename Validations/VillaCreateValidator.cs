using FluentValidation;
using MiPrimeraAPI.Models.DTO;

namespace MiPrimeraAPI.Validations
{
    public class VillaCreateValidator : AbstractValidator<VillaCreateDto>
    {
        public VillaCreateValidator() 
        {
            RuleFor(n => n.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacio.").MinimumLength(2).WithMessage("El nombre es muy corto.");
            RuleFor(n => n.Ciudad).NotEmpty().WithMessage("La ciudad no puede estar vacio.");
            RuleFor(n => n.Pais).NotEmpty().WithMessage("El país no puede estar vacio.");

        }
    }
}
