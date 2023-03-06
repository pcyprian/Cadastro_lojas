
using FluentValidation;

namespace cadastro_lojas_fullstack.Models.Validations
{
    public class EtapaValidation : AbstractValidator<Etapa>
    {
        public EtapaValidation() {

            RuleFor(e => e.etapaProjeto)
                .NotEmpty()
                .NotNull()
                .WithMessage("A etapa não pode ser nula ou vazia");
            RuleFor(e => e.tipoObra)
                .NotEmpty()
                .NotNull()
                .WithMessage("O tipoObra não pode ser nulo ou vazio"); 
            RuleFor(e => e.parceiroSubLocacao)
                .NotEmpty()
                .NotNull()
                .WithMessage("O parceiroSubLocacao deve ser informado");
            RuleFor(e => e.tipoEstacionamento)
                .NotEmpty()
                .NotNull()
                .WithMessage("O tipoEstacionamento deve ser informado");
            RuleFor(e => e.aplicacao)
                .NotEmpty()
                .NotNull()
                .WithMessage("A aplicacao deve ser informado");
            RuleFor(e => e.numeroVagas)
                .NotEmpty()
                .NotNull()
                .WithMessage("O numeroVagas deve ser informado");
            RuleFor(e => e.totem)
                .NotEmpty()
                .NotNull()
                .WithMessage("O totem deve ser informado");
            RuleFor(e => e.toldo)
                .NotEmpty()
                .NotNull()
                .WithMessage("O toldo deve ser informado");
            RuleFor(e => e.elementoHorizontal)
                .NotEmpty()
                .NotNull()
                .WithMessage("O elementoHorizontal deve ser informado");
            RuleFor(e => e.led)
                .NotEmpty()
                .NotNull()
                .WithMessage("O led deve ser informado");
            RuleFor(e => e.dimmer)
                .NotEmpty()
                .NotNull()
                .WithMessage("O dimmer deve ser informado");
            RuleFor(e => e.arCondicionado)
                .NotEmpty()
                .NotNull()
                .WithMessage("O arCondicionado deve ser informado");
            RuleFor(e => e.idProjeto)
                .NotEmpty()
                .NotNull()
                .WithMessage("O idProjeto deve ser informado");
        }

    }
}

