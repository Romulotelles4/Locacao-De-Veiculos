using FluentValidation;

namespace Locadora.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.GrupoVeiculo)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.DiarioDiaria)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);

            RuleFor(x => x.DiarioPorKm)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);


            RuleFor(x => x.LivreDiaria)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ControladoDiaria)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ControladoPorKm)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);

            RuleFor(x => x.ControladoLimiteKm)
              .NotNull()
              .NotEmpty()
              .GreaterThanOrEqualTo(1);


        }
    }
}
