using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos
{
    public partial class TabelaGrupoVeiculoControl : UserControl
    {
        public TabelaGrupoVeiculoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "NOME", HeaderText = "Nome", FillWeight=15F }

            };

            return colunas;
        }

        internal Guid ObtemNumeroRegistroSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<GrupoVeiculo> grupoDeVeiculos)
        {
            grid.Rows.Clear();

            foreach (var grupoDeVeiculo in grupoDeVeiculos)
            {

                grid.Rows.Add(grupoDeVeiculo.Id, grupoDeVeiculo.Nome);
            }
        }
    }
}
