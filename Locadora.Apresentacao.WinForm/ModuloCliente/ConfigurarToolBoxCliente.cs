using Locadora.Apresentacao.WinForm.Compartilhado;

namespace Locadora.Apresentacao.WinForm.ModuloCliente
{
    public class ConfigurarToolBoxCliente : ConfigurarToolboxBase
    {
        public override string TipoCadastro => "Clientes";

        public override string TooltipInserir => "Inserir Cliente";

        public override string TooltipEditar => "Editar Cliente";

        public override string TooltipExcluir => "Excluir Cliente";
    }
}
