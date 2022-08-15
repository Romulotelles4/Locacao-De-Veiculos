using FluentValidation;
using Locadora.Dominio.ModuloCarro;

namespace Locadora.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.CapacidadeTanque)
             .GreaterThanOrEqualTo(1)
             .LessThanOrEqualTo(100)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.GrupoDeVeiculo)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Placa)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(60);
            RuleFor(x => x.Cor)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(60);

            RuleFor(x => x.Marca)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(60);

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(60);

            RuleFor(x => x.KmPercorrido)
               .GreaterThanOrEqualTo(0)
               .NotEmpty()
               .NotNull();
            RuleFor(x => x.TipoDeCombustivel)
               .NotNull();
        }

    }
}
