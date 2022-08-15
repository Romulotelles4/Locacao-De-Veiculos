using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Unit.ModuloPlanoCobranca
{
    [TestClass]
    public class PlanoCobrancaTest
    {
        private GrupoVeiculo grupoVeiculo { get; set; }

        private PlanoCobranca planoCobranca { get; set; }

        public PlanoCobrancaTest()
        {
            grupoVeiculo = new()
            {

                Nome = "esportivo"
            };

            planoCobranca = new()
            {
                GrupoVeiculo = grupoVeiculo,
                DiarioDiaria = 100,
                DiarioPorKm = 4,
                LivreDiaria = 5,
                ControladoDiaria = 2,
                ControladoPorKm = 3,
                ControladoLimiteKm = 8
            };
        }

        [TestMethod]
        public void Cria_objeto_plano_cobranca_com_campos_contrutor()
        {
            // arrange - action
            var planoCobranca = new PlanoCobranca(grupoVeiculo, 100, 4, 5, 2, 3, 8);

            // Asset
            Assert.AreEqual(grupoVeiculo, planoCobranca.GrupoVeiculo);

            // Asset
            Assert.AreEqual(100, planoCobranca.DiarioDiaria);

            // Asset
            Assert.AreEqual(4, planoCobranca.DiarioPorKm);

            // Asset
            Assert.AreEqual(5, planoCobranca.LivreDiaria);

            // Asset
            Assert.AreEqual(2, planoCobranca.ControladoDiaria);

            // Asset
            Assert.AreEqual(3, planoCobranca.ControladoPorKm);

            // Asset
            Assert.AreEqual(8, planoCobranca.ControladoLimiteKm);
        }

        [TestMethod]
        public void Cria_objeto_plano_cobranca_com_todos_atributos_vazio()
        {
            // arrange - action
            var planoCobranca = new PlanoCobranca();

            // Asset
            Assert.AreEqual(null, planoCobranca.GrupoVeiculo);

            // Asset
            Assert.AreEqual(0, planoCobranca.DiarioDiaria);

            // Asset
            Assert.AreEqual(0, planoCobranca.DiarioPorKm);

            // Asset
            Assert.AreEqual(0, planoCobranca.LivreDiaria);

            // Asset
            Assert.AreEqual(0, planoCobranca.ControladoDiaria);

            // Asset
            Assert.AreEqual(0, planoCobranca.ControladoPorKm);

            // Asset
            Assert.AreEqual(0, planoCobranca.ControladoLimiteKm);



        }

        [TestMethod]
        public void Deve_atualizar_campos_condutor()
        {
            // arrange
            var novoPlanoCobranca = new PlanoCobranca();

            // action
            novoPlanoCobranca.Atualizar(planoCobranca);

            // Asset
            Assert.AreEqual(planoCobranca.GrupoVeiculo, novoPlanoCobranca.GrupoVeiculo);

            // Asset
            Assert.AreEqual(planoCobranca.DiarioDiaria, novoPlanoCobranca.DiarioDiaria);

            // Asset
            Assert.AreEqual(planoCobranca.DiarioPorKm, novoPlanoCobranca.DiarioPorKm);

            // Asset
            Assert.AreEqual(planoCobranca.LivreDiaria, novoPlanoCobranca.LivreDiaria);

            // Asset
            Assert.AreEqual(planoCobranca.ControladoDiaria, novoPlanoCobranca.ControladoDiaria);

            // Asset
            Assert.AreEqual(planoCobranca.ControladoPorKm, novoPlanoCobranca.ControladoPorKm);

            // Asset
            Assert.AreEqual(planoCobranca.ControladoLimiteKm, novoPlanoCobranca.ControladoLimiteKm);

        }



    }
}
