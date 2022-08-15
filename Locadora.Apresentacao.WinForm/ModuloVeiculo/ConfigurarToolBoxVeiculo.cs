using Locadora.Apresentacao.WinForm.Compartilhado;

namespace Locadora.Apresentacao.WinForm.ModuloVeiculo
{
    public class ConfigurarToolBoxVeiculo : ConfigurarToolboxBase
    {
        public override string TipoCadastro => "Cadastro Veiculo";

        public override string TooltipInserir => "Inserir Novo Veiculo";

        public override string TooltipEditar => "Editar Veiculo";

        public override string TooltipExcluir => "Excluir Veiculo";
    }
}
