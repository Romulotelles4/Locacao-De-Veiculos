using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloTaxa
{
    public partial class TelaTaxa : Form
    {
        private Taxa _taxa;

        public TelaTaxa(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            btnGravar.Text = label;
        }
        public Taxa Taxa
        {
            get
            {
                return _taxa;
            }
            set
            {
                _taxa = value;
                ConfigurarTela();
            }
        }
        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos");

                DialogResult = DialogResult.None;

                return;
            }

            ConfigurarObjeto();

            var resultadoValidacao = GravarRegistro(Taxa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no Sistema"))
                {
                    MessageBox.Show("Falha no Sistema",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
        private bool ExisteCampoVazio()
        {
            if (string.IsNullOrEmpty(txtBoxDescricao.Text) || string.IsNullOrEmpty(txtBoxValor.Text))
                return true;

            return false;
        }
        private void ConfigurarObjeto()
        {
            Taxa.Descricao=txtBoxDescricao.Text;
            Taxa.Valor = Convert.ToDecimal(txtBoxValor.Text);

            ConfigurarTipoCalculoObjeto();
        }
        private void ConfigurarTipoCalculoObjeto()
        {
            if (checkFixo.Checked)
            {
                Taxa.TipoDeCalculo = TipoDeCalculo.CalculoFixo;
                return;
            }

            Taxa.TipoDeCalculo=TipoDeCalculo.CalculoDiario;
        }
        private void ConfigurarTela()
        {
            txtBoxId.Text = Taxa.Id == default ? "0" : Taxa.Id.ToString();
            txtBoxDescricao.Text = Taxa.Descricao == null ? "" : Taxa.Descricao;
            txtBoxValor.Text = Taxa.Valor == default ? "" : TextBoxBaseExtension.FormatarStringMoedaReal(Taxa.Valor);
            ConfigurarTipoCalculoTela();
        }
        private void ConfigurarTipoCalculoTela()
        {
            if (Taxa.TipoDeCalculo == TipoDeCalculo.CalculoFixo)
            {
                checkFixo.Checked= true;
                return;
            }

            checkDiario.Checked = true;
        }
        private void txtBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }
    }
}
