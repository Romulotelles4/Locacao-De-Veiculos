using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCondutor
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NOME", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "EMAIL", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TELEFONE", HeaderText = "Telefone"},

               new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();

            foreach (Condutor condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Nome, condutor.Email, condutor.Telefone, condutor.Cliente.Nome);
            }
        }
        internal Guid ObtemIdCondutorSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }
    }
}
