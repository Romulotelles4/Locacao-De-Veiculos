using Locadora.Aplicacao.ModuloFuncionario;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private ServiceFuncionario serviceFuncionario;
        TabelaFuncionarioControl tabelaFuncionario;

        public ControladorFuncionario(ServiceFuncionario serviceFuncionario)
        {
            this.serviceFuncionario=serviceFuncionario;
        }

        public override void Editar()
        {
            var id = tabelaFuncionario.ObtemNumeroRegistroSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = serviceFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm("Editar Funcionário", "Editar");

            tela.Funcionario =  resultadoSelecao.Value;

            tela.GravarRegistro = serviceFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var id = tabelaFuncionario.ObtemNumeroRegistroSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = serviceFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed == null)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var registroSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show($"Deseja realmente excluir o funcionário '{registroSelecionado.Nome}'?",
               "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            var resultado = serviceFuncionario.Excluir(registroSelecionado);

            if (resultado.IsSuccess)
                CarregarFuncionarios();
            else
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override void Inserir()
        {
            TelaCadastroFuncionarioForm telaCadastro = new TelaCadastroFuncionarioForm("Inserir Funcionário", "Inserir");

            telaCadastro.Funcionario = new Funcionario();

            telaCadastro.GravarRegistro = serviceFuncionario.Inserir;

            DialogResult resultado = telaCadastro.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarTollboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionario;
        }

        private void CarregarFuncionarios()
        {
            var resultado = serviceFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                tabelaFuncionario.AtualizarRegistros(funcionarios);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
