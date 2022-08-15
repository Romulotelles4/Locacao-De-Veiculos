using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Infra.BancoDados.ModuloCliente;
using Locadora.Infra.BancoDados.ModuloCondutor;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTest : RepositorioBaseTest
    {
        protected override string NomeTabela => "TBCONDUTOR";
        private Cliente _cliente;
        private Condutor _condutor;
        private RepositorioClienteEmBancoDeDados _repositorioCliente;
        private RepositorioCondutor _repositorioCondutor;

        public RepositorioCondutorTest() : base()
        {
            _cliente = new()
            {
                Nome = "romulo",
                Cpf = "12345",
                Cnpj = "123456",
                Cnh = "88888",
                Endereco = "lages",
                Email = "Romulo@gmail.com",
                Telefone = "49999999",
                TipoCadastro = true
            };

            _condutor = new()
            {
                Nome = "Marcos",
                Cpf = "123.456.789.10",
                Cnh = "12345678910",
                Endereco = "Rua teste - lages",
                Email = "condutor@dirigir.com",
                Telefone = "49999993510",
                Cliente = _cliente
            };

            _repositorioCliente = new RepositorioClienteEmBancoDeDados();
            _repositorioCondutor = new RepositorioCondutor();

            LimparTabela("TBCLIENTE");
        }
        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //action
            _repositorioCliente.Inserir(_cliente);
            _repositorioCondutor.Inserir(_condutor);

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(_condutor.Id);

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(true, _condutor.Equals(condutorEncontrado));
        }

        [TestMethod]
        public void Deve_editar_condutor()
        {
            //arrange
            Condutor condutor = new Condutor("Marcos Lima", "01234567891", "12345679811", "rua teste editada", "teste@teste.com", "49999990000", _cliente);

            //action
            _repositorioCliente.Inserir(_cliente);
            _repositorioCondutor.Inserir(_condutor);

            _condutor.Atualizar(condutor);
            _repositorioCondutor.Editar(_condutor);


            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(_condutor.Id);
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(true, condutor.Equals(condutorEncontrado));
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //action
            _repositorioCliente.Inserir(_cliente);
            _repositorioCondutor.Inserir(_condutor);
            _repositorioCondutor.Excluir(_condutor);


            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(_condutor.Id);
            Assert.IsNull(condutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_id()
        {
            //action
            _repositorioCliente.Inserir(_cliente);
            _repositorioCondutor.Inserir(_condutor);

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarPorId(_condutor.Id);
            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(true, _condutor.Equals(condutorEncontrado));
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            //arrange
            Condutor condutor1 = new Condutor("Marcos Lima", "01234567891", "12345679811", "rua do Marcos", "teste@marcos.com", "49999990000", _cliente);
            Condutor condutor2 = new Condutor("José da silva", "98765432100", "98765432110", "rua do José", "teste@jose.com", "48988880000", _cliente);
            Condutor condutor3 = new Condutor("Maria Pereira", "78945612390", "15975365428", "rua da Maria", "teste@maria.com", "47980001111", _cliente);

            //action
            _repositorioCliente.Inserir(_cliente);
            _repositorioCondutor.Inserir(condutor1);
            _repositorioCondutor.Inserir(condutor2);
            _repositorioCondutor.Inserir(condutor3);

            //assert
            var condutorEncontrado = _repositorioCondutor.SelecionarTodos();

            Assert.IsNotNull(condutorEncontrado);
            Assert.AreEqual(3, condutorEncontrado.Count);
        }

    }
}
