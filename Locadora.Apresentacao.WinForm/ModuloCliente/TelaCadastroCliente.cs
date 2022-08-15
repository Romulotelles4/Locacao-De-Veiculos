using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCliente
{
    public partial class TelaCadastroCliente : Form
    {
        public TelaCadastroCliente(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            btnInserir.Text = label;
        }
        private Cliente _cliente;
        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }
        public Cliente Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                ConfigurarTela();
            }
        }
        private void ConfigurarTela()
        {
            textId.Text = _cliente.Id.ToString();
            textNome.Text = _cliente.Nome;
            textCPF.Text = _cliente.Cpf;
            textCNPJ.Text = _cliente.Cnpj;
            textCNH.Text = _cliente.Cnh;
            textEndereco.Text = _cliente.Endereco;
            textEmail.Text = _cliente.Email;
            textTelefone.Text = String.IsNullOrEmpty(_cliente.Telefone) ? "" : TextBoxBaseExtension.FormataStringTelefoneOuCelular(_cliente.Telefone);

            if (_cliente.Id == Guid.Empty)
                SelecionaTipoCadastro();
        }
        private void SelecionaTipoCadastro()
        {
            switch (_cliente.TipoCadastro)
            {
                case true:
                    radioPessoaFisica.Checked = true;
                    break;
                case false:
                    radioPessoaJuridica.Checked = true;
                    break;
            }
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos do formulário");

                DialogResult = DialogResult.None;

                return;
            }
            ConfigurarObjeto();

            var resultadoValidacao = GravarRegistro(_cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema."))
                {
                    MessageBox.Show(erro, "Cadastro Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TelaPrincipalForm.Instancia.AtualizarRodape("");

            if (string.IsNullOrEmpty(textNome.Text) ||
                string.IsNullOrEmpty(textTelefone.Text) ||
                string.IsNullOrEmpty(textEmail.Text) ||
                string.IsNullOrEmpty(textEndereco.Text))
                return true;


            if (radioPessoaFisica.Checked &&
                (string.IsNullOrEmpty(textCPF.Text) ||
                string.IsNullOrEmpty(textCNH.Text)))
                return true;

            if (radioPessoaJuridica.Checked &&
                string.IsNullOrEmpty(textCNPJ.Text))
                return true;

            return false;
        }
        private void ConfigurarObjeto()
        {
            _cliente.Nome = textNome.Text;
            _cliente.Cpf = textCPF.Text;
            _cliente.Cnpj = textCNPJ.Text;
            _cliente.Cnh = textCNH.Text;
            _cliente.Endereco = textEndereco.Text;
            _cliente.Email = textEmail.Text;
            _cliente.Telefone = textTelefone.Text;
            _cliente.TipoCadastro = GerarTipoCadastro();
        }
        private bool GerarTipoCadastro()
        {
            if (radioPessoaFisica.Checked == true)
                return true;

            return false;
        }
        private void radioPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            textCPF.Enabled = true;
            textCNH.Enabled = true;
            textCNPJ.Enabled = false;

            textCNPJ.Clear();
        }
        private void radioPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            textCPF.Enabled = false;
            textCNH.Enabled = false;
            textCNPJ.Enabled = true;

            textCPF.Clear();
            textCNH.Clear();
        }
        private void textTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoTelefoneOuCelulcar(sender, e);
        }
    }
}
