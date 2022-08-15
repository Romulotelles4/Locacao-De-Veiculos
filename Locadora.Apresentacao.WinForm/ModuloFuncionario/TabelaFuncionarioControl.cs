using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "Id", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "NOME", HeaderText = "Nome", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "LOGIN", HeaderText = "Login", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "DATAENTRADA", HeaderText = "Data Entrada", FillWeight=15F },
            };

            return colunas;
        }

        internal Guid ObtemNumeroRegistroSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                //exemplo
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Login, funcionario.DataEntrada);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
