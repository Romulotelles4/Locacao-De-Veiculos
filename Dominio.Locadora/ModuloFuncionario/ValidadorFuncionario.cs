using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Locadora.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .MinimumLength(6).WithMessage("Campo 'Nome' deve ter no mínimo 6 caractes!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .Matches(new Regex(@"^([^0-9]*)$")).WithMessage("Numero não são permitidos para o campo 'Nome!");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(6).WithMessage("Campo 'Login' deve ter no mínimo 6 caractes!");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("O campo 'Senha' é obrigatório!")
                .NotNull().WithMessage("O campo 'Senha' é obrigatório!")
                .MinimumLength(8).WithMessage("'Senha' deve ter no mínimo 8 (oito) caracteres!");

            RuleFor(x => x.DataEntrada)
                .NotEmpty().WithMessage("O campo 'Data de Entrada' é obrigatório!")
                .NotNull().WithMessage("O campo 'Data de Entrada' é obrigatório!")
                .LessThan(p => DateTime.Now).WithMessage("O campo 'Data de Entrada' não deve ser maior que data atual!");
            RuleFor(x => x.Salario)
                .NotEmpty().WithMessage("O campo 'Salário' é obrigatório!")
                .NotNull().WithMessage("O campo 'Salário' é obrigatório!")
                .GreaterThan(0).WithMessage("O campo 'Salário' deve ser maior que 0 (zero)!");
        }
    }
}
