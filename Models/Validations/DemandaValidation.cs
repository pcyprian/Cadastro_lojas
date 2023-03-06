using FluentValidation;

namespace cadastro_lojas_fullstack.Models.Validations
{
    public class DemandaValidation : AbstractValidator<Demanda>
    {
        public DemandaValidation()
        {

            RuleFor(e => e.ArquitetoId)
                .NotEmpty()
                .NotNull()
                .WithMessage("O ArquitetoId não pode ser nulo ou vazio");
            RuleFor(e => e.ApelidoLoja)
                .NotEmpty()
                .NotNull()
                .WithMessage("O ApelidoLoja não pode ser nulo ou vazio");

        }

    }
}