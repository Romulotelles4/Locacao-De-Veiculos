using Locadora.Aplicacao.ModuloCliente;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly ServiceCliente serviceCliente;

        private TabelaClienteControl tabelaClientes;

        public ControladorCliente(ServiceCliente serviceCliente)
        {
            this.serviceCliente = serviceCliente;
        }

        public override void Editar()
        {
            var numero = tabelaClientes.ObtemIdClienteSelecionado();


            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoCliente = serviceCliente.SelecionarPorId(numero);

            if (resultadoCliente.IsFailed)
            {
                MessageBox.Show(resultadoCliente.Errors[0].Message, "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaCadastroCliente tela = new TelaCadastroCliente("Editar Cliente", "Editar");

            tela.Cliente = resultadoCliente.Value;

            tela.GravarRegistro = serviceCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }

        }

        public override void Excluir()
        {
            var numero = tabelaClientes.ObtemIdClienteSelecionado();

            if (numero == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Cliente(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var clienteSelecionado = serviceCliente.SelecionarPorId(numero);

            if (MessageBox.Show("Deseja realmente excluir o cliente?", "Exclusão de Cliente",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = serviceCliente.Excluir(clienteSelecionado.Value);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public override void Inserir()
        {
            TelaCadastroCliente tela = new TelaCadastroCliente("Inserir Cliente", "Inserir");

            tela.Cliente = new Cliente();

            tela.GravarRegistro = serviceCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }
        private Cliente ObtemClienteSelecionado()
        {
            var id = tabelaClientes.ObtemIdClienteSelecionado();

            return serviceCliente.SelecionarPorId(id).Value;
        }

        private void CarregarClientes()
        {
            var resultado = serviceCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                tabelaClientes.AtualizarRegistros(clientes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Listagem de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {

            if (tabelaClientes == null)
                tabelaClientes = new TabelaClienteControl();

            CarregarClientes();

            return tabelaClientes;
        }


    }
}
