using Locadora.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloCliente
{
    [TestClass]
    public class ClienteTest
    {
        private readonly Cliente cliente;

        public ClienteTest()
        {
            cliente = new()
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
        }

        [TestMethod]
        public void Cria_objeto_cliente_com_campos_contrutor()
        {
            // arrange - action
            var ClienteCriar = new Cliente("romulo", "12345", "12345", "12345", "lages", "romulo@gmail.com", "5999444494", true);

            // Asset
            Assert.AreEqual("romulo", ClienteCriar.Nome);

            // Asset
            Assert.AreEqual("12345", ClienteCriar.Cpf);

            // Asset
            Assert.AreEqual("12345", ClienteCriar.Cnpj);

            // Asset
            Assert.AreEqual("12345", ClienteCriar.Cnh);

            // Asset
            Assert.AreEqual("lages", ClienteCriar.Endereco);

            // Asset
            Assert.AreEqual("romulo@gmail.com", ClienteCriar.Email);

            // Asset
            Assert.AreEqual("5999444494", ClienteCriar.Telefone);

            // Asset
            Assert.AreEqual(true, ClienteCriar.TipoCadastro);
        }

        [TestMethod]
        public void Cria_objeto_cliente_com_todos_atributos_vazio()
        {
            // arrange - action
            var ClienteCriar = new Cliente();

            // Asset
            Assert.AreEqual(null, ClienteCriar.Nome);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Cpf);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Cnpj);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Cnh);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Endereco);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Email);

            // Asset
            Assert.AreEqual(null, ClienteCriar.Telefone);

            // Asset
            Assert.AreEqual(false, ClienteCriar.TipoCadastro);


        }

        [TestMethod]
        public void Deve_atualizar_campos_cliente()
        {
            // arrange
            var ClienteCriar = new Cliente();

            // action

            ClienteCriar.Atualizar(cliente);

            // Asset
            Assert.AreEqual(cliente.Nome, ClienteCriar.Nome);

            // Asset
            Assert.AreEqual(cliente.Cpf, ClienteCriar.Cpf);

            // Asset
            Assert.AreEqual(cliente.Cnpj, ClienteCriar.Cnpj);

            // Asset
            Assert.AreEqual(cliente.Cnh, ClienteCriar.Cnh);

            // Asset
            Assert.AreEqual(cliente.Endereco, ClienteCriar.Endereco);

            // Asset
            Assert.AreEqual(cliente.Email, ClienteCriar.Email);

            // Asset
            Assert.AreEqual(cliente.Telefone, ClienteCriar.Telefone);

            // Asset
            Assert.AreEqual(cliente.TipoCadastro, ClienteCriar.TipoCadastro);
        }
    }
}

