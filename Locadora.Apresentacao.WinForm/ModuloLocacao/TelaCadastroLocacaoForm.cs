using FluentResults;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloLocacao;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Funcionario FuncionarioSelecionado { get; set; }
        private List<Taxa> Taxas { get; set; }
        private List<Cliente> Clientes { get; set; }
        private List<Condutor> Condutores { get; set; }
        private List<GrupoVeiculo> GruposVeiculos { get; set; }
        private List<PlanoCobranca> PlanosCobranca { get; set; }
        private List<Veiculo> Veiculos { get; set; }
        public Locacao Locacao { get; private set; }
        public TelaCadastroLocacaoForm(
            string titulo,
            string label,
            Funcionario funcionarioSelecionado,
            List<Cliente> clientes,
            List<GrupoVeiculo> gruposVeiculo,
            List<Taxa> taxas,
            List<Condutor> codutores,
            List<Veiculo> veiculos,
            List<PlanoCobranca> planosCobranca)
        {
            InitializeComponent();
            Text =  titulo;
            btnSalvar.Text = label;
            Locacao = new Locacao();
            FuncionarioSelecionado = funcionarioSelecionado;
            labelFuncionarioSelecionado.Text = FuncionarioSelecionado.Nome;
            Clientes = clientes;
            GruposVeiculos = gruposVeiculo;
            Taxas = taxas;
            Condutores = codutores;
            Veiculos = veiculos;
            PlanosCobranca = planosCobranca;
            PreencherLabel();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        #region Métodos privados
        private void PreencherLabel()
        {
            PreencherClientes();
            PreencherGruposVeiculos();
            PreencherCondutorTela();
            PreencherVeiculo();
            PreencherPlanoCobranca();
            PreencherTaxas();
            labelValorPrevisto.Text = "R$ 0,00";
        }

        private void PreencherTaxas(List<Taxa> taxasSelecionadas = null)
        {
            checkedBoxTaxas.Items.Clear();

            if (taxasSelecionadas == null && Taxas != null && Taxas.Count > 0)
                checkedBoxTaxas.Items.AddRange(Taxas.ToArray());
        }

        private void PreencherPlanoCobranca(GrupoVeiculo grupoVeiculoSelecionado = null)
        {
            cBoxPlanoCobranca.Items.Clear();

            if (grupoVeiculoSelecionado == null)
                cBoxPlanoCobranca.Items.Add("Selecione um Grupo de Veículo");
            else
            {
                cBoxPlanoCobranca.Items.Add("Selecione");

                foreach (int i in Enum.GetValues(typeof(EnumTipoPlanoCobranca)))
                    cBoxPlanoCobranca.Items.Add((EnumTipoPlanoCobranca)i);
            }

            cBoxPlanoCobranca.SelectedIndex = 0;

        }

        private void PreencherVeiculo(GrupoVeiculo grupoVeiculoSelecionado = null)
        {
            cBoxVeiculo.Items.Clear();

            if (grupoVeiculoSelecionado == null)
            {
                cBoxVeiculo.Items.Add("Selecione um Grupo de Veículo");
                txtBoxKmVeiculo.Text = "Nenhum veículo selecionado";
            }
            else
            {
                cBoxVeiculo.Items.Add("Selecione");

                List<Veiculo> veiculosPorGrupoVeiculos = Veiculos.FindAll(x => x.GrupoDeVeiculoId == grupoVeiculoSelecionado.Id);

                foreach (var item in veiculosPorGrupoVeiculos)
                    cBoxVeiculo.Items.Add(item);
            }

            cBoxVeiculo.SelectedIndex = 0;
        }

        private void PreencherCondutorTela(Cliente clienteSelecionado = null)
        {
            cBoxCondutor.Items.Clear();
            if (clienteSelecionado == null)
            {
                cBoxCondutor.Items.Add("Selecione um cliente");
                cBoxCondutor.SelectedIndex = 0;
                return;
            }

            cBoxCondutor.Items.Add("Selecione");

            List<Condutor> condutorPorCliente = Condutores.FindAll(x => x.ClienteId == clienteSelecionado.Id);

            foreach (var item in condutorPorCliente)
                cBoxCondutor.Items.Add(item);

            cBoxCondutor.SelectedIndex = 0;
        }

        private void PreencherGruposVeiculos()
        {
            cBoxGrupoVeiculo.Items.Clear();

            cBoxGrupoVeiculo.Items.Add("Selecione");

            foreach (var item in GruposVeiculos)
                cBoxGrupoVeiculo.Items.Add(item);

            cBoxGrupoVeiculo.SelectedIndex = 0;
        }

        private void PreencherClientes()
        {
            cBoxCliente.Items.Clear();
            cBoxCliente.Items.Add("Selecione");

            foreach (var item in Clientes)
                cBoxCliente.Items.Add(item);

            cBoxCliente.SelectedIndex = 0;
        }

        private void PreencherLocacao()
        {
            if (Locacao == null)
                return;
            Locacao.AddFuncionario(FuncionarioSelecionado);

            if (cBoxCliente.SelectedIndex != 0)
                Locacao.AddCliente((Cliente)cBoxCliente.SelectedItem);



            if (cBoxGrupoVeiculo.SelectedIndex != 0)
                Locacao.AddGrupoVeiculo((GrupoVeiculo)cBoxGrupoVeiculo.SelectedItem);




            if (cBoxPlanoCobranca.SelectedIndex != 0)
            {
                Locacao.AddPlanoCobranca(PlanosCobranca.Find(x => x.GrupoVeiculoId == Locacao.Veiculo.GrupoDeVeiculoId));

                Locacao.TipoPlanoCobranca = (EnumTipoPlanoCobranca)cBoxPlanoCobranca.SelectedItem;
            }

            Locacao.DataInicialLocacao = DateTime.Parse(dateTimePickerLocacao.Text);
            Locacao.DataPrevistaDevolucao = DateTime.Parse(dateTimePickerDevolucao.Text);
            Locacao.QuilometragemInicial = Locacao.Veiculo!= null ? (decimal)Locacao.Veiculo.KmPercorrido : default;
        }

        private void CalcularValorPrevisto()
        {
            if (Locacao == null)
                return;

            DateTime dataSelecionada = dateTimePickerDevolucao.Value;
            
            decimal valor = Locacao.CalcularValor(dataSelecionada, 0);

            labelValorPrevisto.Text = valor.ToString();
        }

        private void cBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCliente == null || cBoxCliente.SelectedIndex == 0)
            {
                PreencherCondutorTela();
                return;
            }

            PreencherCondutorTela((Cliente)cBoxCliente.SelectedItem);

            Locacao.AddCliente((Cliente)cBoxCliente.SelectedItem);
        }

        private void cBoxGrupoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxGrupoVeiculo.SelectedIndex == 0)
            {
                PreencherPlanoCobranca();
                PreencherVeiculo();
                return;
            }

            PreencherPlanoCobranca((GrupoVeiculo)cBoxGrupoVeiculo.SelectedItem);

            PreencherVeiculo((GrupoVeiculo)cBoxGrupoVeiculo.SelectedItem);

            Locacao.AddGrupoVeiculo((GrupoVeiculo)cBoxGrupoVeiculo.SelectedItem);
        }

        private void cBoxVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxVeiculo.SelectedIndex == null || cBoxVeiculo.SelectedIndex == 0)
                return;

            Locacao.AddVeiculo((Veiculo)cBoxVeiculo.SelectedItem);

            txtBoxKmVeiculo.Text = Locacao.Veiculo.KmPercorrido.ToString();
        }

        private void cBoxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxPlanoCobranca.SelectedIndex == default || cBoxPlanoCobranca.SelectedIndex != 0)
                return;

            Locacao.AddPlanoCobranca(PlanosCobranca.Find(x => x.GrupoVeiculoId == Locacao.Veiculo.GrupoDeVeiculoId));

            Locacao.TipoPlanoCobranca = (EnumTipoPlanoCobranca)cBoxPlanoCobranca.SelectedItem;

            CalcularValorPrevisto();
        }

        private void cBoxCondutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCondutor.SelectedIndex == 0)
                return;

            Locacao.AddCondutor((Condutor)cBoxCondutor.SelectedItem);
        }

        private void dateTimePickerDevolucao_ValueChanged(object sender, EventArgs e)
        {
            PreencherLocacao();

            CalcularValorPrevisto();
        }

        private void checkedBoxTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Taxa> taxasSelecionadas = new List<Taxa>();

            foreach(var item in checkedBoxTaxas.CheckedItems)
                taxasSelecionadas.Add((Taxa)item);

            Locacao.Taxas.Clear();

            Locacao.Taxas.AddRange(taxasSelecionadas);

            CalcularValorPrevisto();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ExisteCampoVazio())
            {
                MessageBox.Show("Preencha todos os campos", "Inserir Locação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultadoValidacao = GravarRegistro(Locacao);

            if (resultadoValidacao.IsSuccess)
                return;

            string erro = resultadoValidacao.Errors[0].Message;

            TelaPrincipalForm.Instancia.AtualizarRodape(erro);

            DialogResult = DialogResult.None;

        }

        private bool ExisteCampoVazio()
        {
            return Locacao == null ||
                    Locacao.Cliente is null||
                    Locacao.Condutor is null ||
                    Locacao.Funcionario is null ||
                    Locacao.GrupoVeiculo is null ||
                    Locacao.PlanoCobranca is null ||
                    Locacao.Veiculo is null ||
                    Locacao.DataInicialLocacao == default ||
                    Locacao.DataPrevistaDevolucao == default||
                    Locacao.TipoPlanoCobranca == null ||
                    Locacao.Status == null;
        }

        #endregion métodos privados
    }
}
