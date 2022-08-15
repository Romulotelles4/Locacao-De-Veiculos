using FluentResults;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos
{
    public partial class TelaCadastroGrupoDeVeiculos : Form
    {
        GrupoVeiculo _grupoDeVeiculos;

        public TelaCadastroGrupoDeVeiculos(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            gravarBtn.Text = label;
        }

        public GrupoVeiculo GrupoDeVeiculo
        {
            get { return _grupoDeVeiculos; }
            set
            {
                _grupoDeVeiculos = value;
                ConfigurarTela();
            }

        }
        public Func<GrupoVeiculo, Result<GrupoVeiculo>> GravarRegistro { get; set; }
        private void ConfigurarTela()
        {
            txtBoxId.Text = _grupoDeVeiculos.Id != default ? _grupoDeVeiculos.Id.ToString() : "0";
            TextNomeDoGrupo.Text = string.IsNullOrEmpty(_grupoDeVeiculos.Nome) ? "" : _grupoDeVeiculos.Nome;

        }

        private void gravarBtn_Click(object sender, EventArgs e)
        {

            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos do formulário");

                DialogResult = DialogResult.None;

                return;
            }
            ConfigurarObjeto();

            var resultadoValidacao = GravarRegistro(_grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema."))
                {
                    MessageBox.Show(erro, "Cadastro Grupo De Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrEmpty(TextNomeDoGrupo.Text))
            {
                return true;
            }

            else
                return false;
        }

        private void ConfigurarObjeto()
        {
            _grupoDeVeiculos.Id = Guid.Parse(txtBoxId.Text.ToString());
            _grupoDeVeiculos.Nome = TextNomeDoGrupo.Text;
        }
    }
}
