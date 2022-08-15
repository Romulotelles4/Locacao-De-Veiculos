using FluentAssertions;
using Locadora.Dominio.ModuloCliente;
using Locadora.Infra.Orm.ModuloCliente;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteOrmTest : RepositorioBaseOrmTest
    {
        private RepositorioCliente repositorioCliente;

        public RepositorioClienteOrmTest()
        {
            repositorioCliente = new RepositorioCliente(contextoDadosOrm);
        }

        private Cliente NovoCliente()
        {
            return new Cliente("Bruno", "55663", "1256345", "2348888", "lages sc", "Bruno@hotmail.com", "4999988938", true);
        }

        [TestMethod]
        public void Deve_Inserir_Novo_Cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorioCliente.Inserir(cliente);

            contextoDadosOrm.GravarDados();

            //assert
            var clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            clienteEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Editar_Informacoes_Cliente()
        {
            //arrange
            var cliente = NovoCliente();
            repositorioCliente.Inserir(cliente);
            contextoDadosOrm.GravarDados();

            cliente.Nome = "Romulo Telles";
            cliente.Cpf = "1234567";
            cliente.Cnpj = "123456";
            cliente.Cnh = "123456";
            cliente.Endereco = "Lages-SC";
            cliente.Email = "romulotelles2002@gmail.com";
            cliente.Telefone = "49999460894";
            cliente.TipoCadastro = true;

            //action
            repositorioCliente.Editar(cliente);
            contextoDadosOrm.GravarDados();

            //assert
            var fornecedorEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            fornecedorEncontrado.Should().NotBeNull();
            fornecedorEncontrado.Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            //arrange           
            var cliente = NovoCliente();
            repositorioCliente.Inserir(cliente);
            contextoDadosOrm.GravarDados();

            //action           
            repositorioCliente.Excluir(cliente);
            contextoDadosOrm.GravarDados();

            //assert
            repositorioCliente.SelecionarPorId(cliente.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Apenas_Um_Cliente()
        {
            //arrange          
            var cliente = NovoCliente();
            repositorioCliente.Inserir(cliente);
            contextoDadosOrm.GravarDados();

            //action
            var clienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Clientes()
        {
            //arrange
            var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
            var cliente2 = new Cliente("Eduardo", "456443", "145678765", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);
            var cliente3 = new Cliente("Bruno", "55663", "1256345", "2348888", "lages sc", "Bruno@hotmail.com", "4999988938", true);

            repositorioCliente.Inserir(cliente1);
            repositorioCliente.Inserir(cliente2);
            repositorioCliente.Inserir(cliente3);
            contextoDadosOrm.GravarDados();

            //action
            var cliente = repositorioCliente.SelecionarTodos();

            //assert

            Assert.AreEqual(3, cliente.Count);

            Assert.AreEqual(cliente1.Nome, cliente[0].Nome);
            Assert.AreEqual(cliente2.Nome, cliente[1].Nome);
            Assert.AreEqual(cliente3.Nome, cliente[2].Nome);

        }

    }
}
