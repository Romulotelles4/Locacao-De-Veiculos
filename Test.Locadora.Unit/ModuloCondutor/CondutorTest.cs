using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloCondutor
{
    [TestClass]
    public class CondutorTest
    {
        private Cliente _cliente { get; set; }
        private Condutor _condutor { get; set; }
        public CondutorTest()
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
                Nome = "romulo",
                Cpf = "12345",
                Cnh = "88888",
                Endereco = "lages",
                Email = "Romulo@gmail.com",
                Telefone = "49999999",
                Cliente = _cliente
            };
        }

        [TestMethod]
        public void Cria_objeto_condutor_com_campos_contrutor()
        {
            // arrange - action
            var condutor = new Condutor("romulo", "12345", "12345", "lages", "romulo@gmail.com", "5999444494", _cliente);

            // Asset
            Assert.AreEqual("romulo", condutor.Nome);

            // Asset
            Assert.AreEqual("12345", condutor.Cpf);

            // Asset
            Assert.AreEqual("12345", condutor.Cnh);

            // Asset
            Assert.AreEqual("lages", condutor.Endereco);

            // Asset
            Assert.AreEqual("romulo@gmail.com", condutor.Email);

            // Asset
            Assert.AreEqual("5999444494", condutor.Telefone);

            // Asset
            Assert.AreEqual(true, condutor.Cliente.Equals(_cliente));

        }
        [TestMethod]
        public void Cria_objeto_condutor_com_todos_atributos_vazio()
        {
            // arrange - action
            var condutor = new Condutor();

            // Asset
            Assert.AreEqual(null, condutor.Nome);

            // Asset
            Assert.AreEqual(null, condutor.Cpf);

            // Asset
            Assert.AreEqual(null, condutor.Cnh);

            // Asset
            Assert.AreEqual(null, condutor.Endereco);

            // Asset
            Assert.AreEqual(null, condutor.Email);

            // Asset
            Assert.AreEqual(null, condutor.Telefone);

        }

        [TestMethod]
        public void Deve_atualizar_campos_condutor()
        {
            // arrange
            var novoCondutor = new Condutor();

            // action
            novoCondutor.Atualizar(_condutor);

            // Asset
            Assert.AreEqual(_condutor.Nome, novoCondutor.Nome);

            // Asset
            Assert.AreEqual(_condutor.Cpf, novoCondutor.Cpf);

            // Asset
            Assert.AreEqual(_condutor.Cnh, novoCondutor.Cnh);

            // Asset
            Assert.AreEqual(_condutor.Endereco, novoCondutor.Endereco);

            // Asset
            Assert.AreEqual(_condutor.Email, novoCondutor.Email);

            // Asset
            Assert.AreEqual(_condutor.Telefone, novoCondutor.Telefone);

            // Asset
            Assert.AreEqual(true, novoCondutor.Equals(_condutor));
        }
    }
}