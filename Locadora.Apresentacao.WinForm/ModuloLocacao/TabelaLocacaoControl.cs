using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
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
                new DataGridViewTextBoxColumn { Visible = false, DataPropertyName = "ID", HeaderText = "ID", FillWeight=5F },
                new DataGridViewTextBoxColumn { DataPropertyName = "NOME", HeaderText = "Cliente", FillWeight=35F },
                new DataGridViewTextBoxColumn { DataPropertyName = "VEICULO", HeaderText = "Veículo", FillWeight=30F },
                new DataGridViewTextBoxColumn { DataPropertyName = "DATAINICIALLOCACAO", HeaderText = "Data Locação", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "DATAPREVISTADEVOLUCAO", HeaderText = "Data Prevista Devolução", FillWeight=15F },
            };

            return colunas;
        }

        internal Guid ObtemNumeroRegistroSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (var registro in locacoes)
            {
                //exemplo
                grid.Rows.Add(registro.Id, registro.Cliente.Nome, registro.Veiculo.Modelo, registro.DataInicialLocacao, registro.DataPrevistaDevolucao);
            }
        }
    }
}
