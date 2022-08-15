using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Infra.Orm.ModuloCliente;
using Locadora.Infra.Orm.ModuloCondutor;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTest : RepositorioBaseOrmTest
    {
        private RepositorioCondutor _repositorioCondutor;
        private RepositorioCliente _repositorioCliente;

        public RepositorioCondutorTest()
        {
            _repositorioCondutor = new RepositorioCondutor(contextoDadosOrm);
            _repositorioCliente = new RepositorioCliente(contextoDadosOrm);
            LimparTabela("TbCondutor");
            LimparTabela("TbCliente");
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            var cliente = NovoCliente();
            var condutor = NovoCondutor();
            condutor.Cliente = cliente;

            //action
            _repositorioCliente.Inserir(cliente);
            _repositorioCondutor.Inserir(condutor);
            contextoDadosOrm.GravarDados();

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(true, condutor.Equals(condutorEncontrado));
        }

        [TestMethod]
        public void Deve_editar_condutor()
        {
            //arrange
            var cliente = NovoCliente();
            var condutor = NovoCondutor();
            condutor.Cliente = cliente;
            Condutor condutorAtualizado = new Condutor("Marcos Lima", "01234567891", "12345679811", "rua teste editada", "teste@teste.com", "49999990000", cliente);

            //action
            _repositorioCliente.Inserir(cliente);
            _repositorioCondutor.Inserir(condutor);
            contextoDadosOrm.GravarDados();

            condutor.Atualizar(condutorAtualizado);
            _repositorioCondutor.Editar(condutor);
            contextoDadosOrm.GravarDados();


            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(condutor.Id);
            Assert.IsNotNull(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange
            var cliente = NovoCliente();
            var condutor = NovoCondutor();
            condutor.Cliente = cliente;

            //action
            _repositorioCliente.Inserir(cliente);
            _repositorioCondutor.Inserir(condutor);
            _repositorioCondutor.Excluir(condutor);
            contextoDadosOrm.GravarDados();

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(condutor.Id);
            Assert.IsNull(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            //arrange
            var cliente = NovoCliente();
            var condutor = NovoCondutor();
            condutor.Cliente = cliente;

            //action
            _repositorioCliente.Inserir(cliente);
            _repositorioCondutor.Inserir(condutor);
            contextoDadosOrm.GravarDados();

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(condutor.Id);
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(true, condutor.Equals(condutorEncontrado));
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            //arrange
            var cliente = NovoCliente();
            Condutor condutor1 = new Condutor("Marcos Lima", "01234567891", "12345679811", "rua do Marcos", "teste@marcos.com", "49999990000", cliente);
            Condutor condutor2 = new Condutor("José da silva", "98765432100", "98765432110", "rua do José", "teste@jose.com", "48988880000", cliente);
            Condutor condutor3 = new Condutor("Maria Pereira", "78945612390", "15975365428", "rua da Maria", "teste@maria.com", "47980001111", cliente);

            //action
            _repositorioCliente.Inserir(cliente);
            contextoDadosOrm.GravarDados();

            _repositorioCondutor.Inserir(condutor1);
            contextoDadosOrm.GravarDados();

            _repositorioCondutor.Inserir(condutor2);
            contextoDadosOrm.GravarDados();

            _repositorioCondutor.Inserir(condutor3);
            contextoDadosOrm.GravarDados();

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarTodos();

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(3, condutorEncontrado.Count);
        }

        private Cliente NovoCliente()
        {
            return new Cliente("BrunoCliente", "55663", "1256345", "2348888", "lages sc", "Bruno@hotmail.com", "4999988938", true);
        }

        private Condutor NovoCondutor()
        {
            return new Condutor
            {
                Nome = "Joao condutor",
                Cpf = "12345678930",
                Cnh = "98765432100",
                Endereco = "Rua teste",
                Email = "teste@teste.com",
                Telefone = "49999999999"
            };
        }
    }
}
