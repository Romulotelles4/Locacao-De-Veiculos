using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "TIPO", HeaderText = "Tipo Cadastro"},

                new DataGridViewTextBoxColumn { DataPropertyName = "EMAIL", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TELEFONE", HeaderText = "Telefone"},

           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                string tipo = cliente.TipoCadastro == true ? "Pessoa Física" : "Pessoa Jurídica";
                grid.Rows.Add(cliente.Id, cliente.Nome, tipo, cliente.Email, cliente.Telefone);
            }
        }
        public Guid ObtemIdClienteSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }


        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
