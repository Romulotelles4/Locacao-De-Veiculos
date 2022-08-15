using FluentAssertions;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using Locadora.Infra.BancoDados.ModuloVeiculo;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoBancoDadosTest : RepositorioBaseTest
    {
        protected override string NomeTabela => "TbVeiculo";

        RepositorioVeiculo _repositorio;
        RepositorioGrupoVeiculo _repositorioGrupo;

        GrupoVeiculo _grupoVeiculo;

        Veiculo _veiculo;

        public RepositorioVeiculoBancoDadosTest()
        {
            this._repositorio = new RepositorioVeiculo();
            this._repositorioGrupo = new RepositorioGrupoVeiculo();

            this._grupoVeiculo = new GrupoVeiculo("Turismo");
            this._veiculo = new Veiculo("BMW Z4", "40440-DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina);
            this._veiculo.Foto = new byte[] { 1, 2, 3 };
        }
        [TestMethod]

        public void Deve_Inserir()
        {
            _repositorioGrupo.Inserir(_grupoVeiculo);

            _veiculo.GrupoDeVeiculo = _grupoVeiculo;

            _repositorio.Inserir(_veiculo);

            var veiculoInserido = _repositorio.SelecionarPorId(_veiculo.Id);

            veiculoInserido.Should().Be(_veiculo);
        }
        [TestMethod]
        public void Deve_Editar()
        {
            _repositorioGrupo.Inserir(_grupoVeiculo);

            _veiculo.GrupoDeVeiculo = _grupoVeiculo;

            _repositorio.Inserir(_veiculo);

            Veiculo veiculoEditado = new Veiculo("Uno", "abc-1234", "Fiat", "Azul", 10m, 50m, EnumTipoDeCombustivel.Gasolina);
            veiculoEditado.Foto = new byte[] { 1, 2, 3 };
            veiculoEditado.GrupoDeVeiculo = _grupoVeiculo;

            _veiculo.Atualizar(veiculoEditado);

            _repositorio.Editar(_veiculo);

            var veiculoEncontrado = _repositorio.SelecionarPorId(_veiculo.Id);

            veiculoEncontrado.Should().Be(_veiculo);

        }
        [TestMethod]
        public void Deve_Excluir()
        {
            _repositorioGrupo.Inserir(_grupoVeiculo);

            _veiculo.GrupoDeVeiculo = _grupoVeiculo;

            _repositorio.Excluir(_veiculo);

            var veiculoExcluido = _repositorio.SelecionarPorId(_veiculo.Id);

            veiculoExcluido.Should().BeNull();

        }
        [TestMethod]

        public void Deve_Selecionar_Todos()
        {
            _repositorioGrupo.Inserir(_grupoVeiculo);

            byte[] foto = new byte[] { 1, 2, 3 };
            Veiculo veiculoUm = new Veiculo("BMW Z4", "40440-DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina);
            veiculoUm.Foto = foto;

            Veiculo veiculoDois = new Veiculo("BMW M2", "204242-DD", "BMWM", "LARANJA", 50m, 200M, EnumTipoDeCombustivel.Gasolina);
            veiculoDois.Foto = foto;
            Veiculo veiculoTres = new Veiculo("Stock car", "224242-bb", "Toyota", "Vermelho", 20m, 300m, EnumTipoDeCombustivel.Etanol);
            veiculoTres.Foto = foto;

            veiculoUm.GrupoDeVeiculo= _grupoVeiculo;
            veiculoDois.GrupoDeVeiculo = _grupoVeiculo;
            veiculoTres.GrupoDeVeiculo = _grupoVeiculo;

            _repositorio.Inserir(veiculoUm);
            _repositorio.Inserir(veiculoDois);
            _repositorio.Inserir(veiculoTres);

            var listaVeiculos = _repositorio.SelecionarTodos();

            listaVeiculos[0].Should().Be(veiculoUm);
            listaVeiculos[1].Should().Be(veiculoDois);
            listaVeiculos[2].Should().Be(veiculoTres);
        }

    }
}
