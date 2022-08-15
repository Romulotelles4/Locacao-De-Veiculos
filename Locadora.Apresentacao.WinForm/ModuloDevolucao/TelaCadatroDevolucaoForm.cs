using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloDevolucao;
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

namespace Locadora.Apresentacao.WinForm.ModuloDevolucao
{
    public partial class TelaCadatroDevolucaoForm : Form
    {
        private List<Locacao> locacoes;
        public Locacao locacaoSelecionada { get; private set; }
        public Devolucao Devolucao { get; private set; }

        public TelaCadatroDevolucaoForm(string titulo, string label, List<Locacao> value)
        {
            InitializeComponent();
            Text = titulo;
            btnGravar.Text = label;
            this.locacoes=value;
            Devolucao = new Devolucao();
            PreencherLocacoes();
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; internal set; }

        #region Métodos privados
        private void PreencherLocacoes()
        {
            cBoxLocacoes.Items.Clear();

            cBoxLocacoes.Items.Add("Selecione");

            foreach (var item in locacoes)
                cBoxLocacoes.Items.Add(item);

            cBoxLocacoes.SelectedIndex = 0;
        }
        private void cBoxLocacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxLocacoes.SelectedIndex == 0)
                return;

            locacaoSelecionada = (Locacao)cBoxLocacoes.SelectedItem;

            txtBoxValorTotal.Text = locacaoSelecionada.CalcularValor().ToString();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Devolucao.Locacao = locacaoSelecionada;
            Devolucao.DataDevolucao = DateTime.Parse(dataDevolucao.Text);
            Devolucao.ValorTotal = locacaoSelecionada.CalcularValor(Devolucao.DataDevolucao);

            var resultadoValidacao = GravarRegistro(Devolucao);

            if (resultadoValidacao.IsSuccess)
                return;

            string erro = resultadoValidacao.Errors[0].Message;

            TelaPrincipalForm.Instancia.AtualizarRodape(erro);

            DialogResult = DialogResult.None;
        }
        private void txtBoxValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }
        #endregion

    }
}
