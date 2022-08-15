using FluentValidation.TestHelper;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloPlanoCobranca
{
    [TestClass]
    public class ValidadorPlanoCobrancaTest
    {
        GrupoVeiculo _grupoVeiculo;
        PlanoCobranca _planoCobranca;
        ValidadorPlanoCobranca _validador;
        public ValidadorPlanoCobrancaTest()
        {
            _grupoVeiculo = new GrupoVeiculo("SUV");

            _planoCobranca = new()
            {
                GrupoVeiculo = _grupoVeiculo,
                DiarioDiaria = 100,
                DiarioPorKm = 4,
                LivreDiaria = 5,
                ControladoDiaria = 2,
                ControladoPorKm = 3,
                ControladoLimiteKm = 8
            };

            _validador = new ValidadorPlanoCobranca();
        }
        [TestMethod]
        public void Diario_valor_diario_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.DiarioDiaria = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioDiaria);
        }
        [TestMethod]
        public void Diario_valor_diario_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.DiarioDiaria = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioDiaria);
        }

        [TestMethod]
        public void Diario_valor_por_km_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.DiarioPorKm = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioPorKm);
        }
        [TestMethod]
        public void Diario_valor_por_km_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.DiarioPorKm = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.DiarioPorKm);
        }

        [TestMethod]
        public void Livre_valor_diario_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.LivreDiaria = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.LivreDiaria);
        }
        [TestMethod]
        public void Livre_valor_diario_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.LivreDiaria = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.LivreDiaria);
        }

        [TestMethod]
        public void Controlado_valor_diario_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.ControladoDiaria = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoDiaria);
        }
        [TestMethod]
        public void Controlado_valor_diario_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.ControladoDiaria = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoDiaria);
        }

        [TestMethod]
        public void Controlado_valor_por_km_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.ControladoPorKm = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoPorKm);
        }
        [TestMethod]
        public void Controlado_valor_por_km_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.ControladoPorKm = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoPorKm);
        }

        [TestMethod]
        public void Controlado_limite_de_km_nao_deve_ser_nulo()
        {
            // arrange
            _planoCobranca.ControladoLimiteKm = default;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoLimiteKm);
        }
        [TestMethod]
        public void Controlado_limite_de_km_deve_ser_maior_que_zero()
        {
            // arrange
            _planoCobranca.ControladoLimiteKm = 0;

            // action
            var resultado = _validador.TestValidate(_planoCobranca);

            // assert
            resultado.ShouldHaveValidationErrorFor(f => f.ControladoLimiteKm);
        }
    }
}
