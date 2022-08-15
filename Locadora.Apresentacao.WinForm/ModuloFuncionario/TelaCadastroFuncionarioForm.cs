using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        Funcionario _funcionario;
        public TelaCadastroFuncionarioForm(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            btnSalvar.Text = label;
            txtBoxSenha.PasswordChar = '*';
        }
        public Funcionario Funcionario
        {
            get { return _funcionario; }
            set
            {
                _funcionario = value;
                ConfigurarTela();
            }
        }
        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }
        private void ConfigurarTela()
        {
            txtBoxID.Text = _funcionario.Id != default ? Convert.ToString(_funcionario.Id) : "0";

            txtBoxNome.Text = _funcionario.Nome != null ? _funcionario.Nome : "";

            txtBoxLogin.Text = _funcionario.Login != null ? _funcionario.Login : "";

            txtBoxSenha.Text = _funcionario.Senha != null ? _funcionario.Senha : "";

            rBtnAdministrador.Checked = _funcionario.Administrador;

            dtPickerDataEntrada.Text = _funcionario.DataEntrada != default ? Convert.ToString(_funcionario.DataEntrada) : "";

            txtBoxSalario.Text = _funcionario.Salario != default ? TextBoxBaseExtension.FormatarStringMoedaReal(_funcionario.Salario) : "";
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ExisteCompoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos do formulário");

                DialogResult = DialogResult.None;

                return;
            }

            ConfigurarObjeto();

            var resultadoValidacao = GravarRegistro(Funcionario);

            if (resultadoValidacao.IsSuccess)
                return;

            string erro = resultadoValidacao.Errors[0].Message;

            TelaPrincipalForm.Instancia.AtualizarRodape(erro);

            DialogResult = DialogResult.None;

        }
        private bool ExisteCompoVazio()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");

            if (string.IsNullOrEmpty(txtBoxNome.Text) ||
                string.IsNullOrEmpty(txtBoxLogin.Text) ||
                string.IsNullOrEmpty(txtBoxSenha.Text) ||
                string.IsNullOrEmpty(dtPickerDataEntrada.Text) ||
                string.IsNullOrEmpty(txtBoxSalario.Text))
                return true;


            return false;
        }
        private void ConfigurarObjeto()
        {
            Funcionario.Id = Guid.Parse(txtBoxID.Text.ToString());
            Funcionario.Nome = txtBoxNome.Text;
            Funcionario.Login = txtBoxLogin.Text;
            Funcionario.Senha = txtBoxSenha.Text;
            Funcionario.DataEntrada = Convert.ToDateTime(dtPickerDataEntrada.Text);
            Funcionario.Administrador = rBtnAdministrador.Checked;
            Funcionario.Salario = Convert.ToDecimal(txtBoxSalario.Text);
        }
        #region Métodos privados

        #endregion
        private void txtBoxSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }
        private void checkBoxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarSenha.Checked == true)
            {
                txtBoxSenha.PasswordChar = '\u0000';
                return;
            }

            txtBoxSenha.PasswordChar = '*';
        }
    }
}
