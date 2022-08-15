using FluentAssertions;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.Orm.ModuloGrupoVeiculo;
using Locadora.Infra.Orm.ModuloVeiculo;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoTest : RepositorioBaseOrmTest
    {
        RepositorioVeiculo repositorio;
        RepositorioGrupoVeiculo repositorioGrupo;

        public RepositorioVeiculoTest()
        {
            this.repositorio = new RepositorioVeiculo(contextoDadosOrm);
            this.repositorioGrupo = new RepositorioGrupoVeiculo(contextoDadosOrm);

            LimparTabela("TBVeiculo");
            LimparTabela("TBGrupoVeiculo");
        }

        [TestMethod]

        public void DeveInserirVeiculo()
        {
            var grupo = GerandoGrupoVeiculo();

            repositorioGrupo.Inserir(grupo);

            contextoDadosOrm.GravarDados();

            var veiculo = GerandoVeiculo();

            veiculo.GrupoDeVeiculo = grupo;

            repositorio.Inserir(veiculo);

            contextoDadosOrm.GravarDados();

            var veiculoInserido = repositorio.SelecionarPorId(veiculo.Id);

            veiculoInserido.Should().NotBeNull();
            veiculoInserido.Should().Be(veiculo);
        }
        [TestMethod]
        public void DeveEditarVeiculo()
        {
            var grupo = GerandoGrupoVeiculo();

            contextoDadosOrm.GravarDados();

            repositorioGrupo.Inserir(grupo);

            var veiculo = GerandoVeiculo();

            veiculo.GrupoDeVeiculo = grupo;

            repositorio.Inserir(veiculo);

            contextoDadosOrm.GravarDados();

            veiculo.Marca = "aaaaaaaa";

            repositorio.Editar(veiculo);

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Marca.Should().Be("aaaaaaaa");
        }
        [TestMethod]
        public void DeveExcluirVeiculo()
        {
            var grupo = GerandoGrupoVeiculo();

            contextoDadosOrm.GravarDados();

            repositorioGrupo.Inserir(grupo);

            var veiculo = GerandoVeiculo();

            veiculo.GrupoDeVeiculo = grupo;

            repositorio.Inserir(veiculo);

            contextoDadosOrm.GravarDados();

            repositorio.Excluir(veiculo);

            contextoDadosOrm.GravarDados();

            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            veiculoEncontrado.Should().BeNull();

        }
        [TestMethod]
        public void DeveSelecionarTodosVeiculos()
        {
            var grupo = GerandoGrupoVeiculo();

            repositorioGrupo.Inserir(grupo);

            byte[] foto = new byte[] { 1, 2, 3 };
            Veiculo veiculoUm = new Veiculo("BMW Z4", "40440-DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina);
            veiculoUm.Foto = foto;

            Veiculo veiculoDois = new Veiculo("BMW M2", "204242-DD", "BMWM", "LARANJA", 50m, 200M, EnumTipoDeCombustivel.Gasolina);
            veiculoDois.Foto = foto;
            Veiculo veiculoTres = new Veiculo("Stock car", "224242-bb", "Toyota", "Vermelho", 20m, 300m, EnumTipoDeCombustivel.Etanol);
            veiculoTres.Foto = foto;

            veiculoUm.GrupoDeVeiculo = grupo;
            veiculoDois.GrupoDeVeiculo = grupo;
            veiculoTres.GrupoDeVeiculo = grupo;

            repositorio.Inserir(veiculoUm);
            repositorio.Inserir(veiculoDois);
            repositorio.Inserir(veiculoTres);

            contextoDadosOrm.GravarDados();

            var listaVeiculos = repositorio.SelecionarTodos();

            listaVeiculos[0].Should().Be(veiculoUm);
            listaVeiculos[1].Should().Be(veiculoDois);
            listaVeiculos[2].Should().Be(veiculoTres);
        }

        private Veiculo GerandoVeiculo()
        {
            var veiculo = new Veiculo("BMW Z4", "40440 - DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina);

            veiculo.Foto = new byte[] { 1, 2, 3 };

            return veiculo;
        }
        private GrupoVeiculo GerandoGrupoVeiculo()
        {
            return new GrupoVeiculo("Suv");
        }

    }
}
