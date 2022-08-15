

using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using Locadora.Infra.BancoDados.ModuloPlanoCobranca;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaBancoDadosTest : RepositorioBaseTest
    {
        protected override string NomeTabela => "TBPLANOCOBRANCA";

        private GrupoVeiculo grupoVeiculo;
        private RepositorioGrupoVeiculo repositorioGrupoVeiculo;

        private PlanoCobranca planoCobranca;
        private RepositorioPlanoCobrancaBancoDados repositorioPlanoCobranca;

        public RepositorioPlanoCobrancaBancoDadosTest() : base()
        {

            grupoVeiculo = new()
            {
                Nome = "Esportivo"
            };

            planoCobranca = new()
            {

                GrupoVeiculo = grupoVeiculo,
                DiarioDiaria = 2,
                DiarioPorKm = 3,
                LivreDiaria = 4,
                ControladoDiaria = 5,
                ControladoPorKm = 6,
                ControladoLimiteKm = 7

            };

            this.repositorioGrupoVeiculo = new RepositorioGrupoVeiculo();
            this.repositorioPlanoCobranca = new RepositorioPlanoCobrancaBancoDados();

        }

        [TestMethod]
        public void Deve_Inserir_Plano_Cobranca()
        {
            //action
            repositorioGrupoVeiculo.Inserir(grupoVeiculo);
            repositorioPlanoCobranca.Inserir(planoCobranca);

            //assert
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoCobrancaEncontrado);
            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Plano_Cobranca()
        {
            //Arrange
            PlanoCobranca planoCobrancaEditada = new PlanoCobranca(grupoVeiculo, 1, 2, 3, 4, 5, 6);

            //Action
            repositorioGrupoVeiculo.Inserir(grupoVeiculo);

            repositorioPlanoCobranca.Inserir(planoCobranca);

            planoCobranca.Atualizar(planoCobrancaEditada);

            repositorioPlanoCobranca.Editar(planoCobranca);

            //Assert
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            Assert.IsNotNull(planoCobrancaEncontrado);
            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_Excluir_Plano_Cobranca()
        {
            //Action
            repositorioGrupoVeiculo.Inserir(grupoVeiculo);

            repositorioPlanoCobranca.Inserir(planoCobranca);

            repositorioPlanoCobranca.Excluir(planoCobranca);

            //Assert
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            Assert.IsNull(planoCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_Plano_Cobranca()
        {
            //Arrange
            PlanoCobranca planoCobranca1 = new PlanoCobranca(grupoVeiculo, 1, 2, 3, 4, 5, 6);
            PlanoCobranca planoCobranca2 = new PlanoCobranca(grupoVeiculo, 6, 7, 8, 9, 10, 11);
            PlanoCobranca planoCobranca3 = new PlanoCobranca(grupoVeiculo, 12, 13, 14, 15, 16, 17);

            //Action
            repositorioGrupoVeiculo.Inserir(grupoVeiculo);

            repositorioPlanoCobranca.Inserir(planoCobranca1);
            repositorioPlanoCobranca.Inserir(planoCobranca2);
            repositorioPlanoCobranca.Inserir(planoCobranca3);


            //Assert
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarTodos();

            Assert.AreEqual(3, planoCobrancaEncontrado.Count);
        }
    }
}
