using FluentResults;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobranca : Form
    {
        public TelaCadastroPlanoCobranca(string titulo, string label)
        {
            InitializeComponent();
            Text = titulo;
            btnInserir.Text = label;
        }

        private PlanoCobranca _planoCobranca;
        public List<GrupoVeiculo> _grupoVeiculos;
        public List<GrupoVeiculo> GrupoVeiculos
        {
            get { return _grupoVeiculos; }
            set
            {
                _grupoVeiculos = value;
                PreencherCBoxGrupoVeiculo();
            }
        }

        private void PreencherCBoxGrupoVeiculo()
        {
            comboBoxGrupoVeiculo.Items.Clear();

            comboBoxGrupoVeiculo.Items.Add("Selecionar Grupo Veículo");

            foreach (var item in _grupoVeiculos)
                comboBoxGrupoVeiculo.Items.Add(item);

            comboBoxGrupoVeiculo.SelectedIndex = 0;
        }

        public Func<PlanoCobranca, Result<PlanoCobranca>> GravarRegistro { get; set; }

        public PlanoCobranca PlanoCobranca
        {
            get { return _planoCobranca; }
            set
            {
                _planoCobranca = value;
                ConfigurarTela();
            }
        }
        private void ConfigurarTela()
        {
            txtBoxId.Text = _planoCobranca.Id == default ? "0" : _planoCobranca.Id.ToString();
            txtBoxControladoDiaria.Text = _planoCobranca.ControladoDiaria == default ? "" : _planoCobranca.ControladoDiaria.ToString();
            txtBoxControladoPorKm.Text = _planoCobranca.ControladoPorKm == default ? "" : _planoCobranca.ControladoPorKm.ToString();
            txtBoxControladoLimteKm.Text = _planoCobranca.ControladoLimiteKm == default ? "" : _planoCobranca.ControladoLimiteKm.ToString();
            txtBoxDiarioDiaria.Text = _planoCobranca.DiarioDiaria == default ? "" : _planoCobranca.DiarioDiaria.ToString();
            txtBoxDiarioPorKm.Text = _planoCobranca.DiarioPorKm == default ? "" : _planoCobranca.DiarioPorKm.ToString();
            txtBoxLivreDiaria.Text = _planoCobranca.LivreDiaria == default ? "" : _planoCobranca.LivreDiaria.ToString();
            comboBoxGrupoVeiculo.SelectedItem = _planoCobranca.GrupoVeiculo == null ? comboBoxGrupoVeiculo.SelectedItem : _planoCobranca.GrupoVeiculo;
        }

        private void txtBoxControladoDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void txtBoxControladoPorKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void txtBoxControladoLimteKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void txtBoxDiarioDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void txtBoxDiarioPorKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void txtBoxLivreDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxBaseExtension.FormatarCampoMoedaReal(sender, e);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Preencha todos os campos do formulário!");
                DialogResult = DialogResult.None;
                return;
            }

            ConfigurarObjeto();

            var resultado = GravarRegistro(_planoCobranca);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema."))
                {
                    MessageBox.Show(erro, "Cadastro Plano De Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void ConfigurarObjeto()
        {
            _planoCobranca.GrupoVeiculo = (GrupoVeiculo)comboBoxGrupoVeiculo.SelectedItem;
            _planoCobranca.ControladoDiaria  = Convert.ToDecimal(txtBoxControladoDiaria.Text);
            _planoCobranca.ControladoPorKm = Convert.ToDecimal(txtBoxControladoPorKm.Text);
            _planoCobranca.ControladoLimiteKm = Convert.ToDecimal(txtBoxControladoLimteKm.Text);
            _planoCobranca.DiarioDiaria = Convert.ToDecimal(txtBoxDiarioDiaria.Text);
            _planoCobranca.DiarioPorKm = Convert.ToDecimal(txtBoxDiarioPorKm.Text);
            _planoCobranca.LivreDiaria = Convert.ToDecimal(txtBoxLivreDiaria.Text);
        }

        private bool ExisteCampoVazio()
        {
            if (string.IsNullOrEmpty(txtBoxControladoDiaria.Text) ||
                string.IsNullOrEmpty(txtBoxControladoPorKm.Text) ||
                string.IsNullOrEmpty(txtBoxControladoLimteKm.Text) ||
                string.IsNullOrEmpty(txtBoxDiarioDiaria.Text) ||
                string.IsNullOrEmpty(txtBoxDiarioPorKm.Text) ||
                string.IsNullOrEmpty(txtBoxLivreDiaria.Text) ||
                comboBoxGrupoVeiculo.SelectedIndex == 0
                ) return true;

            return false;
        }
    }
}