
using FluentValidation;

namespace cadastro_lojas_fullstack.Models.Validations
{
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation() {

            RuleFor(x => x.Bandeira).NotEmpty().NotNull();
            RuleFor(x => x.ApelidoProjeto).NotEmpty().NotNull();
            RuleFor(x => x.Cep).NotEmpty().NotNull().Length(8);
            RuleFor(x => x.Estado).NotEmpty().NotNull().Length(2);
            RuleFor(x => x.Municipio).NotEmpty().NotNull();
            RuleFor(x => x.Categoria).NotEmpty().NotNull();
            RuleFor(x => x.PerfilArquitetonico).NotEmpty().NotNull();
            RuleFor(x => x.Ativo).NotEmpty().NotNull();
            RuleFor(x => x.DemandaId).NotEmpty().NotNull();
        }

    }
}
