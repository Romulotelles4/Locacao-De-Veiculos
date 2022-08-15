using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Locadora.Test.Unit.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private readonly Funcionario funcionario;
        private readonly ValidadorFuncionario validador;

        public ValidadorFuncionarioTest()
        {
            funcionario = new()
            {
                Nome = "Marcos Adriano Lima",
                Login = "admin1",
                Senha = "admin1",
                DataEntrada = new DateTime(2022, 01, 01),
                Administrador = false,
                Salario = 50.00m
            };

            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Nome = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Nome_Deve_Ser_Valido()
        {
            // arrange
            funcionario.Nome = "321Rech_Fernandes";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Nome);
        }

        [TestMethod]
        public void Login_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Login = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Login_Deve_Ser_Valido()
        {
            // arrange
            funcionario.Login = "admin";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Login);
        }

        [TestMethod]
        public void Senha_Deve_Ser_Obrigatorio()
        {
            // arrange
            funcionario.Senha = null;

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Senha_Deve_Ser_Valido()
        {
            // arrange
            funcionario.Senha = "admin";

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.Senha);
        }

        [TestMethod]
        public void Deta_entrada_nao_deve_Ser_menor_data_atual()
        {

            // arrange
            funcionario.DataEntrada = DateTime.Now.AddDays(1);

            // action
            var resultado = validador.TestValidate(funcionario);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DataEntrada);
        }
    }
}
