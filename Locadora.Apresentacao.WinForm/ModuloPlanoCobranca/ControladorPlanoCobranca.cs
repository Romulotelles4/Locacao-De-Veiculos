using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Aplicacao.ModuloPlanoCobranca;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private readonly ServicePlanoCobranca servicePlanoCobranca;
        private readonly ServiceGrupoVeiculo serviceGrupoVeiculo;
        private TabelaPlanoCobrancaControl tabelaPlanoCobranca;

        public ControladorPlanoCobranca(ServicePlanoCobranca servicePlanoCobranca, ServiceGrupoVeiculo serviceGrupoVeiculo)
        {
            this.servicePlanoCobranca = servicePlanoCobranca;
            this.serviceGrupoVeiculo = serviceGrupoVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca("Inserir Plano de Cobrança", "Inserir");

            var resultadoGrupoVeiculos = serviceGrupoVeiculo.SelecionarTodos();

            if (resultadoGrupoVeiculos.Value.Count == 0)
            {
                MessageBox.Show("Nenhum Grupo de Veículos cadastrado",
               "Inserir Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tela.GrupoVeiculos = resultadoGrupoVeiculos.Value;

            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicePlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }
        }

        public override void Editar()
        {
            var numero = tabelaPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();


            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicePlanoCobranca.SelecionarPorId(numero);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultadoGrupoVeiculos = serviceGrupoVeiculo.SelecionarTodos();

            if (resultadoGrupoVeiculos.Value.Count == 0)
            {
                MessageBox.Show("Nenhum Grupo de Veículos cadastrado",
               "Inserir Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TelaCadastroPlanoCobranca tela = new TelaCadastroPlanoCobranca("Editar Plano", "Editar");

            tela.GrupoVeiculos = resultadoGrupoVeiculos.Value;

            tela.PlanoCobranca = resultado.Value;

            tela.GravarRegistro = servicePlanoCobranca.Editar;

            DialogResult resultadoPlano = tela.ShowDialog();

            if (resultadoPlano == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }

        }

        public override void Excluir()
        {
            var numero = tabelaPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Plano(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var planoSelecionado = servicePlanoCobranca.SelecionarPorId(numero);

            if (MessageBox.Show("Deseja realmente excluir o Plano?", "Exclusão de Plano",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicePlanoCobranca.Excluir(planoSelecionado.Value);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanoCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Planos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarPlanoCobranca()
        {
            var resultado = servicePlanoCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> planos = resultado.Value;

                tabelaPlanoCobranca.AtualizarRegistros(planos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Planos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {

            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanoCobranca();

            return tabelaPlanoCobranca;
        }
    }
}
