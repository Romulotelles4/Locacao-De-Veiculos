using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Locadora.Test.Unit.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class ValidadorGrupoVeiculoTest
    {

        ValidadorGrupoVeiculo validador;

        GrupoVeiculo grupoDeVeiculo;

        public ValidadorGrupoVeiculoTest()
        {
            validador = new ValidadorGrupoVeiculo();
            grupoDeVeiculo = new GrupoVeiculo()
            {
                Id = new Guid(),
                Nome = "a3434434"
            };
        }

        [TestMethod]

        public void Nome_Nao_Pode_Ser_Null()
        {
            grupoDeVeiculo.Nome = null;

            var resultado = validador.TestValidate(grupoDeVeiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
        [TestMethod]
        public void Nome_Nao_Pode_Ter_Numero()
        {
            grupoDeVeiculo.Nome = "11111";

            var resultado = validador.TestValidate(grupoDeVeiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }
}
