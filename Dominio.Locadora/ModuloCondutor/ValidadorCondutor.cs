using FluentValidation;


namespace Locadora.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
              .NotNull().WithMessage("O campo 'Nome' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Nome' não pode ser vazio!")
              .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Nome' não permite caracteres especiais!")
              .MinimumLength(2).WithMessage("O campo 'Nome' deve conter no mínimo 2 caracteres!")
              .MaximumLength(50);

            RuleFor(x => x.Endereco)
              .NotNull().WithMessage("O campo 'Endereço' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Endereço' não pode ser vazio!")
              .MinimumLength(4).WithMessage("O campo 'Endereço' deve conter no mínimo 4 caracteres!");

            RuleFor(x => x.Telefone)
              .NotNull().WithMessage("O campo 'Telefone' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Telefone' não pode ser vazio!")
              .MinimumLength(10).WithMessage("O campo 'Telefone' deve conter no mínimo 10 caracteres!")
              .MaximumLength(16).WithMessage("O campo 'Telefone' deve conter no máximo 16 caracteres!");

            RuleFor(x => x.Email)
              .NotNull().WithMessage("O campo 'Email' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Email' não pode ser vazio!")
              .MinimumLength(8).WithMessage("O campo 'Email' deve conter no mínimo 8 caracteres!")
              .EmailAddress().WithMessage("Formato campo 'Email' inválidpo!");

            RuleFor(x => x.Cpf)
              .NotNull().WithMessage("O campo 'Cpf' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Cpf' não pode ser vazio!")
              .IsValidCPF().WithMessage("Formato do campo 'Cpf' inválido!");

            RuleFor(x => x.Cnh)
              .NotNull().WithMessage("O campo 'Cnh' não pode ser nulo!")
              .NotEmpty().WithMessage("O campo 'Cnh' não pode ser vazio!")
              .Length(11).WithMessage("O campo 'Cnh' deve conter 11 números!");

        }
    }
}
