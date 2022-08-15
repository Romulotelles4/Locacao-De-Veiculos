using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest
    {
        private ValidadorVeiculo validador;
        private Veiculo veiculo;

        public ValidadorVeiculoTest()
        {
            this.validador = new ValidadorVeiculo();
            gerandoVeiculo();
        }

        [TestMethod]
        private void Marca_Nao_Pode_Ser_Nulo()
        {
            veiculo.Marca = null;
            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }
        [TestMethod]
        private void Cor_Nao_Pode_Ser_Nulo()
        {
            veiculo.Cor = null;
            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]

        private void Modelo_Nao_Pode_Ser_Nulo()
        {
            veiculo.Modelo = null;
            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }
        [TestMethod]

        private void Placa_Nao_Pode_Ser_Nulo()
        {
            veiculo.Placa = null;
            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.Placa);
        }
        [TestMethod]
        private void KmPercorrido_Nao_Pode_Ser_Nulo()
        {
            veiculo.KmPercorrido = null;
            var resultado = validador.TestValidate(veiculo);

            resultado.ShouldHaveValidationErrorFor(x => x.KmPercorrido);
        }




        private void gerandoVeiculo()
        {
            veiculo = new Veiculo("BMW Z4", "40440-DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina);
        }
    }
}
