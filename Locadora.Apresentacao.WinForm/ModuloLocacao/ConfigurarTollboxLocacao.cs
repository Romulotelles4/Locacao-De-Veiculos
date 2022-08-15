using Locadora.Apresentacao.WinForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    public class ConfigurarTollboxLocacao : ConfigurarToolboxBase
    {
        public override string TipoCadastro => "Locações";

        public override string TooltipInserir => "Inserir Locação";

        public override string TooltipEditar => "Editar Locação";

        public override string TooltipExcluir => "Excluir Locação";

        public override bool InserirHabilitado { get { return true; } }

        public override bool EditarHabilitado { get { return false; } }

        public override bool ExcluirHabilitado { get { return true; } }

        public override bool FiltrarHabilitado { get { return true; } }

        public override bool GerarPdfHabilitado { get { return true; } }

    }
}
