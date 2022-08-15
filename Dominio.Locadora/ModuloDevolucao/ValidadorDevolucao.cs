using FluentValidation;

namespace Locadora.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            RuleFor(x => x.ValorTotal)
              .NotNull().WithMessage("O campo 'Valor' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Valor' não pode ser vazio!")
              .GreaterThan(0).WithMessage("O campo 'Valor' não pode ser menor que 0 'zero'!");

        }
    }
}
