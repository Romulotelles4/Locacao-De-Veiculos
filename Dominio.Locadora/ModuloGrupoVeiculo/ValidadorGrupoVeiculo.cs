using FluentValidation;

namespace Locadora.Dominio.ModuloGrupoDeVeiculo
{
    public class ValidadorGrupoVeiculo : AbstractValidator<GrupoVeiculo>
    {
        public ValidadorGrupoVeiculo()
        {
            RuleFor(x => x.Nome)
               .NotNull()
               .MaximumLength(60)
               .MinimumLength(2)
               .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
               .NotEmpty();
        }
    }
}
