using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private readonly Cliente cliente;
        private readonly ValidadorCliente validador;

        public ValidadorClienteTest()
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

            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            cliente.Nome = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }


        [TestMethod]
        public void Telefone_Deve_Ser_Obrigatorio()
        {
            // arrange
            cliente.Telefone = null;

            // action
            var resultado = validador.TestValidate(cliente);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

    }
}
