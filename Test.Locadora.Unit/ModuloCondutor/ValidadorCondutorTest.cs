using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private Cliente _cliente { get; set; }
        private Condutor _condutor { get; set; }

        private ValidadorCondutor _validador { get; set; }
        public ValidadorCondutorTest()
        {
            _cliente = new()
            {

                Nome = "Romulo",
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
                Cpf = "01202195903",
                Cnh = "12345678911",
                Endereco = "lages",
                Email = "Romulo@gmail.com",
                Telefone = "49999999",
                Cliente = _cliente
            };
            _validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Nome = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Deve_nao_Ser_vazio()
        {
            // arrange
            _condutor.Nome = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_nao_Deve_permitir_caracteres_especiais()
        {
            // arrange
            _condutor.Nome = "marcos # teste";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_nao_deve_conter_mais_de_50_caracteres()
        {
            // arrange
            _condutor.Nome = "marcos sdasfasfa fasfasfas fasfasfas fsafaf fsafasfa";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Endereco_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Endereco = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Endereco_Deve_nao_Ser_vazio()
        {
            // arrange
            _condutor.Endereco = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Endereco_nao_deve_conter_menos_4_caracteres()
        {
            // arrange
            _condutor.Endereco = "abc";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Endereco);
        }

        [TestMethod]
        public void Telefone_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Telefone = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Telefone_nao_Deve_Ser_vazio()
        {
            // arrange
            _condutor.Telefone = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Telefone);
        }

        [TestMethod]
        public void Email_nao_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Email = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Email_nao_Deve_Ser_vazio()
        {
            // arrange
            _condutor.Email = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }

        [TestMethod]
        public void Email_deve_conter_formato_valido()
        {
            // arrange
            _condutor.Email = "teste.com";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Email);
        }


        [TestMethod]
        public void Cpf_nao_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Cpf = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_nao_Deve_Ser_vazio()
        {
            // arrange
            _condutor.Cpf = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido()
        {
            // arrange
            _condutor.Cpf = "12346579811";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cpf);
        }

        [TestMethod]
        public void Cnh_nao_Deve_nao_Ser_nulo()
        {
            // arrange
            _condutor.Cnh = null;

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

        [TestMethod]
        public void Cnh_nao_Deve_Ser_vazio()
        {
            // arrange
            _condutor.Cnh = "";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

        [TestMethod]
        public void Cnh_deve_conter_11_caracteres()
        {
            // arrange
            _condutor.Cnh = "0123465789";

            // action
            var resultado = _validador.TestValidate(_condutor);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Cnh);
        }

    }
}
