using FluentValidation;

namespace cadastro_lojas_fullstack.Models.Validations
{
    public class MedidaValidation :AbstractValidator<Medida>
    {
        public MedidaValidation()
        {
            RuleFor(x => x.AreaVendas).NotNull().NotEmpty();
            RuleFor(x => x.AreaConstruidaVendas).NotNull().NotEmpty();
            RuleFor(x => x.AreaApoioTerreo).NotNull().NotEmpty();
            RuleFor(x => x.AreaApoioMezanino).NotNull().NotEmpty();
            RuleFor(x => x.AreaEstacionamentoCoberto).NotNull().NotEmpty();
            RuleFor(x => x.AreaNaoutilizadaTerreo).NotNull().NotEmpty();
            RuleFor(x => x.AreaNaoutilizadaSup).NotNull().NotEmpty();
            RuleFor(x => x.AreaEstacionamentoDescoberto).NotNull().NotEmpty();
            RuleFor(x => x.AreaAjardinada).NotNull().NotEmpty();
            RuleFor(x => x.AreaDescobSemPiso).NotNull().NotEmpty();
            RuleFor(x => x.AreaTerreno).NotNull().NotEmpty();
        }
    }
}
