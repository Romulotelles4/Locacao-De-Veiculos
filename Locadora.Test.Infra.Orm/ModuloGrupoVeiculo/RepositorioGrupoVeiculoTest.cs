using FluentAssertions;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Infra.Orm.ModuloGrupoVeiculo;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloGrupoVeiculo
{
    [TestClass]
    public class RepositorioGrupoVeiculoTest : RepositorioBaseOrmTest
    {
        private RepositorioGrupoVeiculo repositorio;

        public RepositorioGrupoVeiculoTest()
        {
            repositorio = new RepositorioGrupoVeiculo(contextoDadosOrm);
            LimparTabela("TBGrupoVeiculo");
        }

        [TestMethod]

        public void DeveInserirGrupoVeiculo()
        {
            var novoGrupo = GerandoGrupoVeiculo();

            repositorio.Inserir(novoGrupo);

            contextoDadosOrm.GravarDados();

            var grupoEncontrado = repositorio.SelecionarPorId(novoGrupo.Id);

            grupoEncontrado.Should().NotBeNull();
        }
        [TestMethod]
        public void DeveEditarGrupoVeiculo()
        {
            var novoGrupo = GerandoGrupoVeiculo();

            repositorio.Inserir(novoGrupo);

            contextoDadosOrm.GravarDados();

            novoGrupo.Nome = "carro";

            repositorio.Editar(novoGrupo);

            var grupoEditado = repositorio.SelecionarPorId(novoGrupo.Id);

            grupoEditado.Nome.Should().Be("carro");
        }
        [TestMethod]
        public void DeveExcluirGrupoVeiculo()
        {
            var novoGrupo = GerandoGrupoVeiculo();

            repositorio.Inserir(novoGrupo);

            contextoDadosOrm.GravarDados();

            repositorio.Excluir(novoGrupo);

            contextoDadosOrm.GravarDados();

            var grupoExcluido = repositorio.SelecionarPorId(novoGrupo.Id);

            grupoExcluido.Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodos()
        {
            var novoGrupo = GerandoGrupoVeiculo();

            var novoGrupo2 = new GrupoVeiculo("carro");

            var novoGrupo3 = new GrupoVeiculo("bbbb");

            repositorio.Inserir(novoGrupo);
            repositorio.Inserir(novoGrupo2);
            repositorio.Inserir(novoGrupo3);

            contextoDadosOrm.GravarDados();

            var todosGrupos = repositorio.SelecionarTodos();

            todosGrupos.Count.Should().Be(3);

        }

        private GrupoVeiculo GerandoGrupoVeiculo()
        {
            return new GrupoVeiculo("Suv");
        }
    }
}
