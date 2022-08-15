using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoVeiculo : ControladorBase
    {
        ServiceGrupoVeiculo serviceGrupoDeVeiculos;
        TabelaGrupoVeiculoControl tabela;

        public ControladorGrupoVeiculo(ServiceGrupoVeiculo serviceGrupoDeVeiculos)
        {
            this.serviceGrupoDeVeiculos=serviceGrupoDeVeiculos;
        }

        public override void Editar()
        {

            var numero = tabela.ObtemNumeroRegistroSelecionado();


            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Edição de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoGrupo = serviceGrupoDeVeiculos.SelecionarPorId(numero);

            if (resultadoGrupo.IsFailed)
            {
                MessageBox.Show(resultadoGrupo.Errors[0].Message, "Edição de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaCadastroGrupoDeVeiculos tela = new TelaCadastroGrupoDeVeiculos("Editar Grupo", "Editar");

            tela.GrupoDeVeiculo = resultadoGrupo.Value;

            tela.GravarRegistro = serviceGrupoDeVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoDeVeiculos();
            }
        }

        public override void Excluir()
        {
            var numero = tabela.ObtemNumeroRegistroSelecionado();

            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Exclusão de Grupo(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupoSelecionado = serviceGrupoDeVeiculos.SelecionarPorId(numero);

            if (MessageBox.Show("Deseja realmente excluir o grupo?", "Exclusão de Grupos",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = serviceGrupoDeVeiculos.Excluir(grupoSelecionado.Value);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoDeVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculos telaCadastro = new TelaCadastroGrupoDeVeiculos("Inserir Grupo de Veículo", "Inserir");

            telaCadastro.GrupoDeVeiculo = new GrupoVeiculo();

            telaCadastro.GravarRegistro = serviceGrupoDeVeiculos.Inserir;

            DialogResult resultado = telaCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupoDeVeiculos();
        }

        private void CarregarGrupoDeVeiculos()
        {
            var resultado = serviceGrupoDeVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoVeiculo> grupos = resultado.Value;

                tabela.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Grupos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (tabela == null)
                tabela= new TabelaGrupoVeiculoControl();

            CarregarGrupoDeVeiculos();

            return tabela;
        }
    }
}
