using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculo.Nome", HeaderText = "Grupo de veículo"}
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<PlanoCobranca> planoCobrancas)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca planoCobranca in planoCobrancas)
                grid.Rows.Add(planoCobranca.Id, planoCobranca.GrupoVeiculo.Nome);
        }
        public Guid ObtemIdPlanoCobrancaSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }
    }
}
