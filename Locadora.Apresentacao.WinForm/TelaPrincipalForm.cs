using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator;
using Locadora.Apresentacao.WinForm.ModuloCliente;
using Locadora.Apresentacao.WinForm.ModuloCondutor;
using Locadora.Apresentacao.WinForm.ModuloDevolucao;
using Locadora.Apresentacao.WinForm.ModuloFuncionario;
using Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos;
using Locadora.Apresentacao.WinForm.ModuloLocacao;
using Locadora.Apresentacao.WinForm.ModuloPlanoCobranca;
using Locadora.Apresentacao.WinForm.ModuloTaxa;
using Locadora.Apresentacao.WinForm.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        IServiceLocator serviceLocator;

        public TelaPrincipalForm(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            this.serviceLocator = serviceLocator;
            //InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            statusStripMensagem.Items.Clear();
            statusStripMensagem.Items.Add(mensagem);
        }

        private void ConfigurarBotoes(ConfigurarToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }

        private void ConfigurarTooltips(ConfigurarToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }

        private void ConfigurarToolbox()
        {
            ConfigurarToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void taxaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
        }

        private void grupoVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoVeiculo>());
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
        }
        private void planoDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoCobranca>());
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorDevolucao>());
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutor>());
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculo>());
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorLocacao>());
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

    }
}
