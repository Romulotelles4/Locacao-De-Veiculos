using Locadora.Apresentacao.WinForm.Compartilhado;

namespace Locadora.Apresentacao.WinForm.ModuloFuncionario
{
    public class ConfigurarTollboxFuncionario : ConfigurarToolboxBase
    {
        public override string TipoCadastro => "Funcionários";

        public override string TooltipInserir => "Inserir Funcionário";

        public override string TooltipEditar => "Editar Funcionário";

        public override string TooltipExcluir => "Excluir Funcionário";
    }
}
