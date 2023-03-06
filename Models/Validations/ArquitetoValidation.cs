using FluentValidation;

namespace cadastro_lojas_fullstack.Models.Validations
{
    public class ArquitetoValidation : AbstractValidator<Arquiteto>
    {
        public ArquitetoValidation() {

            RuleFor(x => x.nomeArquiteto).NotNull().NotEmpty();
            RuleFor(x => x.cnpjArquiteto).NotNull().NotEmpty().Length(14);
            RuleFor(x => x.emailArquiteto).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.ativo).NotNull().NotEmpty();
        }

    }
}
