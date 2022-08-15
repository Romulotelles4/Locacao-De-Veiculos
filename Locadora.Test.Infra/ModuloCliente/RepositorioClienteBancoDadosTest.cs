using Locadora.Dominio.ModuloCliente;
using Locadora.Infra.BancoDados.ModuloCliente;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteBancoDadosTest : RepositorioBaseTest
    {
        private Cliente cliente;
        private RepositorioClienteEmBancoDeDados repositorio;

        protected override string NomeTabela => "TBCLIENTE";

        public RepositorioClienteBancoDadosTest()
        {
            cliente = new Cliente();
            cliente.Nome = "Romulo Telles";
            cliente.Cpf = "1234567";
            cliente.Cnpj = "123456";
            cliente.Cnh = "123456";
            cliente.Endereco = "Lages-SC";
            cliente.Email = "romulotelles2002@gmail.com";
            cliente.Telefone = "49999460894";
            cliente.TipoCadastro = true;

            repositorio = new RepositorioClienteEmBancoDeDados();
        }


        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_cliente()
        {
            //arrange                      
            repositorio.Inserir(cliente);

            //action
            cliente.Nome = "Pedro Augusto";
            cliente.Cpf = "1234";
            cliente.Cnpj = "1234";
            cliente.Cnh = "1234";
            cliente.Endereco = "florianopolis";
            cliente.Email = "junior@hotmail.com";
            cliente.Telefone = "4999232345";
            cliente.TipoCadastro = false;


            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange           
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);
            Assert.IsNull(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_cliente()
        {
            //arrange          
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
            var cliente2 = new Cliente("Eduardo", "456443", "145678765", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);
            var cliente3 = new Cliente("Bruno", "55663", "1256345", "2348888", "lages sc", "Bruno@hotmail.com", "4999988938", true);

            repositorio.Inserir(cliente1);
            repositorio.Inserir(cliente2);
            repositorio.Inserir(cliente3);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, clientes.Count);

            Assert.AreEqual(cliente1.Nome, clientes[0].Nome);
            Assert.AreEqual(cliente2.Nome, clientes[1].Nome);
            Assert.AreEqual(cliente3.Nome, clientes[2].Nome);
        }

        //[TestMethod]
        //public void Nao_deve_inserir_cpf_duplicado()
        //{
        //    //arrange
        //    var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
        //    var cliente2 = new Cliente("Eduardo", "12333", "145678765", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);

        //    //action
        //    repositorio.Inserir(cliente1);
        //    repositorio.Inserir(cliente2);

        //    //assert
        //    var clienteEncontrado = repositorio.SelecionarTodos();

        //    Assert.AreEqual(1, clienteEncontrado.Count);
        //}

        [TestMethod]
        public void Nao_deve_editar_cliente_com_cpf_igual_outro_cliente()
        {
            ////arrange
            //var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
            //var cliente2 = new Cliente("Eduardo", "456443", "145678765", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);

            ////action
            //repositorio.Inserir(cliente1);
            //repositorio.Inserir(cliente2);

            //cliente1.Cpf = "12333";
            //var resultado = repositorio.Editar(cliente1);

            ////assert
            //Assert.AreEqual(false, resultado.IsValid);
        }

        //[TestMethod]
        //public void Nao_deve_inserir_cnpf_duplicado()
        //{
        //    //arrange
        //    var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
        //    var cliente2 = new Cliente("Eduardo", "456443", "12345", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);

        //    //action
        //    repositorio.Inserir(cliente1);
        //    repositorio.Inserir(cliente2);

        //    //assert
        //    var clienteEncontrado = repositorio.SelecionarTodos();

        //    Assert.AreEqual(1, clienteEncontrado.Count);
        //}

        [TestMethod]
        public void Nao_deve_editar_cliente_com_cnpj_igual_outro_cliente()
        {
            ////arrange
            //var cliente1 = new Cliente("Matheus de Souza", "12333", "12345", "888888", "lages sc", "Matheus@hotmail.com", "4999988938", true);
            //var cliente2 = new Cliente("Eduardo", "456443", "145678765", "845678", "curitiba", "Eduardo@hotmail.com", "4999778", false);

            ////action
            //repositorio.Inserir(cliente1);
            //repositorio.Inserir(cliente2);

            //cliente1.Cnpj = "12345";
            //var resultado = repositorio.Editar(cliente1);

            ////assert
            //Assert.AreEqual(false, resultado.IsValid);
        }
    }
}