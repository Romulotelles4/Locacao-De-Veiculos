using FluentValidation;

namespace Locadora.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
              .NotNull()
              .NotEmpty()
              .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
              .WithMessage("Caracteres especiais não são permitidos!")
              .MaximumLength(50);

            RuleFor(x => x.Endereco)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Telefone)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Email)
              .NotNull()
              .NotEmpty()
              .EmailAddress();

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty()
                .IsValidCPF()
                .When(x => x.TipoCadastro == true);

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .NotNull()
                .IsValidCNPJ()
                .When(x => x.TipoCadastro == false);

        }

    }
}
