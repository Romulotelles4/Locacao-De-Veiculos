using Locadora.Apresentacao.WinForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Apresentacao.WinForm.ModuloDevolucao
{
    public class ConfigurarToolboxDevolucao : ConfigurarToolboxBase
    {
        public override string TipoCadastro => "Devolução";

        public override string TooltipInserir => "Inserir Devolução";

        public override string TooltipEditar => "Editar Devolução";

        public override string TooltipExcluir => "Excluir Devolução";

        public override bool InserirHabilitado { get { return true; } }

        public override bool EditarHabilitado { get { return false; } }

        public override bool ExcluirHabilitado { get { return false; } }

        public override bool FiltrarHabilitado { get { return false; } }

        public override bool GerarPdfHabilitado { get { return true; } }
    }
}
