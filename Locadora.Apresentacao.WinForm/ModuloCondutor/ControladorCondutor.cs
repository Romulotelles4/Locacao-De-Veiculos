using Locadora.Aplicacao.ModuloCliente;
using Locadora.Aplicacao.ModuloCondutor;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private ServiceCondutor _serviceCondutor;

        private ServiceCliente _serviceCliente;

        private TabelaCondutorControl tabelaCondutor;
        
        public ControladorCondutor(ServiceCondutor serviceCondutor, ServiceCliente serviceCliente)
        {
            this._serviceCondutor=serviceCondutor;
            this._serviceCliente = serviceCliente;
        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _serviceCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm("Editar Condutor", "Editar");

            var resultadoSelecionarClientes = _serviceCliente.SelecionarTodos();

            if (resultadoSelecionarClientes.IsSuccess)
                tela.Clientes = resultadoSelecionarClientes.Value;
            else
            {
                MessageBox.Show(resultadoSelecionarClientes.Errors[0].Message, "Seleção de clientes",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            tela.Condutor = resultadoSelecao.Value;

            tela.GravarRegistro = _serviceCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _serviceCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed == null)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            DialogResult dialogResult = MessageBox.Show($"Deseja realmente excluir o condutor '{condutorSelecionado.Nome}'?",
               "Exclusão de Condutor(s)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.OK)
                return;

            var resultado = _serviceCondutor.Excluir(condutorSelecionado);

            if (resultado.IsFailed)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(resultado.Errors[0].Message);
                return;
            }

            CarregarCondutores();

        }

        public override void Inserir()
        {
            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm("Inserir Condutor", "Inserir");

            var resultadoSelecionarClientes = _serviceCliente.SelecionarTodos();

            if (resultadoSelecionarClientes.Value.Count == 0)
            {
                MessageBox.Show("Nenhum cliente cadastrado. O cadastro de condutor necessita de um cliente cadastrado!",
                "Inserir Condutor(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tela.Clientes = resultadoSelecionarClientes.Value;

            tela.Condutor = new Condutor();

            tela.GravarRegistro = _serviceCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();

        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private void CarregarCondutores()
        {
            var resultado = _serviceCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                tabelaCondutor.AtualizarRegistros(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de condutores",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
