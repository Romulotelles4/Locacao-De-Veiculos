using FluentAssertions;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Infra.Orm.ModuloGrupoVeiculo;
using Locadora.Infra.Orm.ModuloPlanoCobranca;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaOrmTest : RepositorioBaseOrmTest
    {
        private RepositorioPlanoCobranca repositorioPlanoCobranca;
        private RepositorioGrupoVeiculo repositorioGrupoVeiculo;

        public RepositorioPlanoCobrancaOrmTest()
        {
            repositorioGrupoVeiculo = new RepositorioGrupoVeiculo(contextoDadosOrm);
            repositorioPlanoCobranca = new RepositorioPlanoCobranca(contextoDadosOrm);
        }

        private GrupoVeiculo GerarGrupoVeiculo()
        {
            GrupoVeiculo novoGrupoVeiculo = new GrupoVeiculo();

            novoGrupoVeiculo.Nome = "Esportivo";
            repositorioGrupoVeiculo.Inserir(novoGrupoVeiculo);
            contextoDadosOrm.GravarDados();

            return novoGrupoVeiculo;
        }

        private PlanoCobranca GerarPlanoCobranca()
        {
            PlanoCobranca novoPlanoCobranca = new PlanoCobranca();
            var grupoVeiculo = GerarGrupoVeiculo();

            novoPlanoCobranca.GrupoVeiculo = grupoVeiculo;
            novoPlanoCobranca.DiarioDiaria = 2;
            novoPlanoCobranca.DiarioPorKm = 3;
            novoPlanoCobranca.LivreDiaria = 4;
            novoPlanoCobranca.ControladoDiaria = 5;
            novoPlanoCobranca.ControladoPorKm = 6;
            novoPlanoCobranca.ControladoLimiteKm = 7;

            return novoPlanoCobranca;
        }

        [TestMethod]
        public void Deve_Inserir_Novo_PlanoCobranca()
        {
            //arrange
            var novoPlanoCobranca = GerarPlanoCobranca();
            var grupoVeiculo = GerarGrupoVeiculo();
            novoPlanoCobranca.GrupoVeiculo = grupoVeiculo;

            //Action
            repositorioPlanoCobranca.Inserir(novoPlanoCobranca);
            contextoDadosOrm.GravarDados();

            //Assert
            var planoInserido = repositorioPlanoCobranca.SelecionarPorId(novoPlanoCobranca.Id);
            planoInserido.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Editar_PlanoCobranca()
        {
            //arrange
            var novoPlano = GerarPlanoCobranca();

            repositorioPlanoCobranca.Inserir(novoPlano);

            contextoDadosOrm.GravarDados();

            novoPlano.DiarioDiaria = 22;
            novoPlano.DiarioPorKm = 35;
            novoPlano.LivreDiaria = 44;
            novoPlano.ControladoDiaria = 53;
            novoPlano.ControladoPorKm = 62;
            novoPlano.ControladoLimiteKm = 17;

            //action
            repositorioPlanoCobranca.Editar(novoPlano);

            contextoDadosOrm.GravarDados();

            //assert
            var planoEditado = repositorioPlanoCobranca.SelecionarPorId(novoPlano.Id);

            planoEditado.Should().NotBeNull();
            planoEditado.Should().Be(novoPlano);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoCobranca()
        {
            //arrange
            var novoPlano = GerarPlanoCobranca();
            repositorioPlanoCobranca.Inserir(novoPlano);

            contextoDadosOrm.GravarDados();

            novoPlano.DiarioDiaria = 22;
            novoPlano.DiarioPorKm = 35;
            novoPlano.LivreDiaria = 44;
            novoPlano.ControladoDiaria = 53;
            novoPlano.ControladoPorKm = 62;
            novoPlano.ControladoLimiteKm = 17;
            //Action
            repositorioPlanoCobranca.Excluir(novoPlano);
            contextoDadosOrm.GravarDados();

            //Assert
            var planoExcluido = repositorioPlanoCobranca.SelecionarPorId(novoPlano.Id);
            planoExcluido.Should().BeNull();

        }

        [TestMethod]
        public void Deve_Selecionar_Apenas_Um_PlanoCobranca()
        {
            //arrange
            var planoCobranca = GerarPlanoCobranca();
            repositorioPlanoCobranca.Inserir(planoCobranca);
            contextoDadosOrm.GravarDados();

            //action
            var planoCobrancaEncontrado = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            //assert
            Assert.IsNotNull(planoCobrancaEncontrado);
            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_PlanosCobranca()
        {
            //arrange
            var grupoVeiculo1 = GerarGrupoVeiculo();
            var grupoVeiculo2 = GerarGrupoVeiculo();

            var planoCobranca1 = new PlanoCobranca(grupoVeiculo1, 2, 3, 4, 5, 6, 7);
            var planoCobranca2 = new PlanoCobranca(grupoVeiculo2, 56, 44, 776, 34, 22, 11);

            repositorioPlanoCobranca.Inserir(planoCobranca1);
            repositorioPlanoCobranca.Inserir(planoCobranca2);

            contextoDadosOrm.GravarDados();

            //action
            var planoCobranca = repositorioPlanoCobranca.SelecionarTodos();

            //assert
            Assert.AreEqual(2, planoCobranca.Count);

            Assert.AreEqual(planoCobranca1.GrupoVeiculo, planoCobranca[0].GrupoVeiculo);
            Assert.AreEqual(planoCobranca2.GrupoVeiculo, planoCobranca[1].GrupoVeiculo);


        }

    }
}
