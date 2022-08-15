using Locadora.Aplicacao.ModuloCliente;
using Locadora.Aplicacao.ModuloCondutor;
using Locadora.Aplicacao.ModuloFuncionario;
using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Aplicacao.ModuloLocacao;
using Locadora.Aplicacao.ModuloPlanoCobranca;
using Locadora.Aplicacao.ModuloTaxa;
using Locadora.Aplicacao.ModuloVeiculo;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacao;
        private ServiceLocacao serviceLocacao;
        private ServiceCliente serviceCliente;
        private ServiceCondutor serviceCondutor;
        private ServiceFuncionario serviceFuncionario;
        private ServiceGrupoVeiculo serviceGrupoDeVeiculos;
        private ServicePlanoCobranca servicePlanoCobranca;
        private ServiceVeiculo serviceVeiculo;
        private ServiceTaxa serviceTaxa;

        public ControladorLocacao(
            ServiceLocacao serviceLocacao, 
            ServiceCliente serviceCliente, 
            ServiceCondutor servicecondutor, 
            ServiceFuncionario serviceFuncionario, 
            ServiceGrupoVeiculo serviceGrupoDeVeiculos, 
            ServicePlanoCobranca servicePlanoCobranca, 
            ServiceVeiculo serviceVeiculo, 
            ServiceTaxa serviceTaxa)
        {
            this.serviceLocacao=serviceLocacao;
            this.serviceCliente=serviceCliente;
            this.serviceCondutor=servicecondutor;
            this.serviceFuncionario=serviceFuncionario;
            this.serviceGrupoDeVeiculos=serviceGrupoDeVeiculos;
            this.servicePlanoCobranca=servicePlanoCobranca;
            this.serviceVeiculo=serviceVeiculo;
            this.serviceTaxa=serviceTaxa;
        }
        public override void Inserir()
        {
            var resultadoSelecaoTaxas = serviceTaxa.SelecionarTodos();
            var resultadoSelecaoClientes = serviceCliente.SelecionarTodos();
            var resultadoSelecaoFuncionarios = serviceFuncionario.SelecionarTodos();
            var resultadoSelecaoCondutores = serviceCondutor.SelecionarTodos();
            var resultadoSelecaoGrupoVeiculo = serviceGrupoDeVeiculos.SelecionarTodos();
            var resultadoSelecaoPlanoCobranca = servicePlanoCobranca.SelecionarTodos();
            var resultadoSelecaoVeiculos = serviceVeiculo.SelecionarTodos();

            TelaSelecaoFuncionarioForm telaSelecaoFuncionario = new TelaSelecaoFuncionarioForm(resultadoSelecaoFuncionarios.Value);

            if (telaSelecaoFuncionario.ShowDialog() == DialogResult.Cancel)
                return;

            TelaCadastroLocacaoForm telaCadastroLocacao = new TelaCadastroLocacaoForm(
                "Inserir Locação", 
                "Inserir",
                telaSelecaoFuncionario.funcionarioSelecionado,
                resultadoSelecaoClientes.Value,
                resultadoSelecaoGrupoVeiculo.Value,
                resultadoSelecaoTaxas.Value,
                resultadoSelecaoCondutores.Value,
                resultadoSelecaoVeiculos.Value,
                resultadoSelecaoPlanoCobranca.Value
                );

            telaCadastroLocacao.GravarRegistro = serviceLocacao.Inserir;

            if (telaCadastroLocacao.ShowDialog() == DialogResult.Cancel)
                return;

            CarregarLocacoes();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            var id = tabelaLocacao.ObtemNumeroRegistroSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = serviceLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var locacaoExcluir = resultadoSelecao.Value;

            if (MessageBox.Show($"Deseja realmente excluir a Locação? \nCliente: {locacaoExcluir.Cliente.Nome} - Veículo: {locacaoExcluir.Veiculo.Modelo}", "Exclusão de Locação",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            var resultado = serviceLocacao.Excluir(locacaoExcluir);

            if (resultado.IsSuccess)
                CarregarLocacoes();
            else
                MessageBox.Show(resultado.Errors[0].Message,"Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void Filtrar()
        {
            TelaFiltroLocacaoForm telaFiltroLocacao = new TelaFiltroLocacaoForm();
                
            var resultadoFiltro = telaFiltroLocacao.ShowDialog();

            if (resultadoFiltro == DialogResult.Cancel)
                return;

            var locacoesFiltradas = serviceLocacao.SelecionarPorStatus(telaFiltroLocacao.statusLocacaoFiltro);

            if (locacoesFiltradas.IsSuccess) 
            { 
                tabelaLocacao.AtualizarRegistros(locacoesFiltradas.Value);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoesFiltradas.Value.Count} Locação(s)");
                return;
            }
            else
            {
                MessageBox.Show(locacoesFiltradas.Errors[0].Message, "Filtrar de Locações",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarTollboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaLocacao == null)
                tabelaLocacao = new TabelaLocacaoControl();

            CarregarLocacoes();

            return tabelaLocacao;
        }

        private void CarregarLocacoes()
        {
            var resultado = serviceLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacao.AtualizarRegistros(locacoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
