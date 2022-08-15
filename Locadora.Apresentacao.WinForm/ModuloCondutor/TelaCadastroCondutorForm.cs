using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor _condutor;
        List<Cliente> _clientes;
        public TelaCadastroCondutorForm(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            btnInserir.Text = label;
        }
        public Condutor Condutor
        {
            get { return _condutor; }
            set
            {
                _condutor = value;
                ConfigurarTela(_condutor);
            }
        }

        public List<Cliente> Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                PopularComboBoxCliente();
            }
        }

        private void ConfigurarTela(Condutor condutor)
        {
            txtBoxId.Text = condutor.Id != default ? condutor.Id.ToString() : "0";
            txtBoxNome.Text = string.IsNullOrEmpty(condutor.Nome) ? "" : condutor.Nome;
            maskedTxtBoxCpf.Text = string.IsNullOrEmpty(condutor.Cpf) ? "" : condutor.Cpf;
            maskedTxtBoxCnh.Text = string.IsNullOrEmpty(condutor.Cnh) ? "" : condutor.Cnh;
            txtBoxEndereco.Text = string.IsNullOrEmpty(condutor.Endereco) ? "" : condutor.Endereco;
            txtBoxEmail.Text = string.IsNullOrEmpty(condutor.Email) ? "" : condutor.Email;
            txtBoxTelefone.Text = string.IsNullOrEmpty(condutor.Telefone) ? "" : TextBoxBaseExtension.FormataStringTelefoneOuCelular(condutor.Telefone);

            if (condutor.Cliente != null)
                cBoxCliente.SelectedItem = condutor.Cliente;
        }

        private void PopularComboBoxCliente()
        {
            cBoxCliente.Items.Clear();

            cBoxCliente.Items.Add("Selecione um cliente");

            foreach (var item in _clientes)
                cBoxCliente.Items.Add(item);

            cBoxCliente.SelectedItem = "Selecione um cliente";
        }

        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos!");
                DialogResult = DialogResult.None;
                return;
            }
            ConfigurarObjeto();

            var resultado = GravarRegistro(_condutor);

            if (resultado.IsSuccess)
                return;

            TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);
            DialogResult = DialogResult.None;
        }

        private bool ExisteCampoVazio()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");

            if (string.IsNullOrEmpty(txtBoxNome.Text) ||
                string.IsNullOrEmpty(maskedTxtBoxCpf.Text) ||
                string.IsNullOrEmpty(maskedTxtBoxCnh.Text) ||
                string.IsNullOrEmpty(txtBoxEndereco.Text) ||
                string.IsNullOrEmpty(txtBoxEmail.Text) ||
                string.IsNullOrEmpty(txtBoxTelefone.Text) ||
                cBoxCliente.SelectedIndex == 0)
                return true;

            return false;

        }

        private void ConfigurarObjeto()
        {
            Cliente cliente = (Cliente)cBoxCliente.SelectedItem;

            _condutor.Id = Guid.Parse(txtBoxId.Text.ToString());
            _condutor.Nome = txtBoxNome.Text;
            _condutor.Cpf = maskedTxtBoxCpf.Text;
            _condutor.Cnh = maskedTxtBoxCnh.Text;
            _condutor.Endereco = txtBoxEndereco.Text;
            _condutor.Email = txtBoxEmail.Text;
            _condutor.Telefone = TextBoxBaseExtension.RetirarCaracteresEspeciais(txtBoxTelefone.Text);
            _condutor.Cliente = cliente;
        }

        private void checkBoxCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxCliente.Checked)
                return;

            if (cBoxCliente.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Seleção cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                checkBoxCliente.Checked = false;
                return;
            }

            Cliente cliente = (Cliente)cBoxCliente.SelectedItem;

            if (!cliente.TipoCadastro)
            {
                MessageBox.Show("Os dados do cliente selecionado não podem ser utilizado. Apenas cliente pessoa física pode ser utilizado!",
                "Seleção cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                checkBoxCliente.Checked = false;
                return;
            }

            Condutor condutor = new()
            {
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Cnh = cliente.Cnh,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Cliente = cliente
            };

            ConfigurarTela(condutor);
        }

        private void LimparCampos()
        {
            txtBoxNome.Text = "";
            maskedTxtBoxCpf.Text = "";
            maskedTxtBoxCnh.Text = "";
            txtBoxEndereco.Text = "";
            txtBoxEmail.Text = "";
            txtBoxTelefone.Text = "";
            cBoxCliente.SelectedIndex = 0;
            checkBoxCliente.Checked = false;
        }

        private void limparCamposLinkLabel_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente limpar os campos?", "Limpar campos preenchidos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.Cancel)
                return;

            LimparCampos();
        }

        private void txtBoxTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoTelefoneOuCelulcar(sender, e);
        }

    }
}
