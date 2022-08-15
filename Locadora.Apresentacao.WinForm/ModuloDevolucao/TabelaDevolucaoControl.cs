using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloDevolucao
{
    public partial class TabelaDevolucaoControl : UserControl
    {
        public TabelaDevolucaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Visible = false ,DataPropertyName = "ID", HeaderText = "Id", FillWeight=5F },
                new DataGridViewTextBoxColumn { DataPropertyName = "LOCACAO.CLIENTE.NOME", HeaderText = "Cliente", FillWeight=50F },
                new DataGridViewTextBoxColumn { DataPropertyName = "LOCACAO.DATAINICIALLOCACAO", HeaderText = "Data locação", FillWeight=20F },
                new DataGridViewTextBoxColumn { DataPropertyName = "LOCACAO.DATADEVOLUCAOREALIZADA", HeaderText = "Data Devolução", FillWeight=20F },
            };

            return colunas;
        }

        internal Guid ObtemNumeroRegistroSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            grid.Rows.Clear();

            foreach (var devolucao in devolucoes)
            {
                //exemplo
                grid.Rows.Add(devolucao.Id, devolucao.Locacao.Cliente.Nome, devolucao.Locacao.DataInicialLocacao, devolucao.DataDevolucao);
            }
        }
    }
}
