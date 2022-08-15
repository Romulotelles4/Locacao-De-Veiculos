using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {
        public TabelaTaxaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descricao", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor", FillWeight=15F },
                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo de Calculo", HeaderText = "Tipo de Calculo", FillWeight=15F }
            };

            return colunas;
        }

        internal Guid ObtemNumeroMateriaSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();

            foreach (var taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.Descricao, taxa.Valor, taxa.TipoDeCalculo);
                //exemplo
                //grid.Rows.Add(materia.Numero, materia.Nome, materia.Disciplina.Nome, materia.Serie.GetDescription());
            }
        }
    }
}
