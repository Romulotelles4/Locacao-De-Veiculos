using FluentAssertions;
using Locadora.Dominio.ModuloGrupoDeVeiculo;

using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloGrupoDeVeiculo
{
    [TestClass]
    public class RepositorioGrupoVeiculoBancoDadosTest : RepositorioBaseTest
    {
        private RepositorioGrupoVeiculo repositorio;

        protected override string NomeTabela => "TBGRUPOVEICULO";

        public RepositorioGrupoVeiculoBancoDadosTest()
        {
            repositorio = new RepositorioGrupoVeiculo();
        }

        [TestMethod]
        public void Deve_inserir_novo_GrupoDeVeiculo()
        {
            var grupo = GerandoGrupoDeVeiculo();

            repositorio.Inserir(grupo);

            var grupoInserido = repositorio.SelecionarPorId(grupo.Id);

            grupoInserido.Should().NotBeNull();

            grupoInserido.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_Editar_GrupoDeVeiculo()
        {
            var grupo = GerandoGrupoDeVeiculo();

            repositorio.Inserir(grupo);

            grupo.Nome = "Suv";

            repositorio.Editar(grupo);

            var grupoEditado = repositorio.SelecionarPorId(grupo.Id);

            grupoEditado.Should().NotBeNull();
            grupoEditado.Should().Be(grupo);

        }

        [TestMethod]
        public void Deve_Excluir_GrupoDeVeiculo()
        {
            var grupo = GerandoGrupoDeVeiculo();

            repositorio.Inserir(grupo);

            repositorio.Excluir(grupo);

            var grupoExcluido = repositorio.SelecionarPorId(grupo.Id);

            grupoExcluido.Should().BeNull();

        }

        [TestMethod]
        public void Deve_Selecionar_Todos_GrupoDeVeiculo()
        {
            var grupoUm = GerandoGrupoDeVeiculo();

            var grupoDois = new GrupoVeiculo();
            grupoDois.Nome = "StockCar";

            var grupoTres = new GrupoVeiculo();
            grupoTres.Nome = "gt";

            repositorio.Inserir(grupoUm);
            repositorio.Inserir(grupoDois);
            repositorio.Inserir(grupoTres);

            var grupos = repositorio.SelecionarTodos();

            grupos[0].Should().Be(grupoUm);
            grupos[1].Should().Be(grupoDois);
            grupos[2].Should().Be(grupoTres);
        }

        //[TestMethod]
        //public void Nao_deve_inserir_novo_GrupoDeVeiculo_com_nome_duplicado()
        //{
        //    //arrange
        //    var grupo = GerandoGrupoDeVeiculo();


        //    //action
        //    repositorio.Inserir(grupo);

        //    repositorio.Inserir(grupo);


        //    //assert
        //    var grupoInserido = repositorio.SelecionarTodos();

        //    Assert.AreEqual(1, grupoInserido.Count);
        //}

        [TestMethod]
        public void Nao_deve_ditar_GrupoDeVeiculo_com_nome_duplicado()
        {
            ////arrange
            //var grupo1 = new GrupoVeiculo("Monoposto");
            //var grupo2 = new GrupoVeiculo("SUV");

            //repositorio.Inserir(grupo1);
            //repositorio.Inserir(grupo2);

            ////action
            //grupo1.Nome = "SUV";

            //var resultado = repositorio.Editar(grupo1);

            ////assert
            //Assert.AreEqual(false, resultado.IsValid);
        }

        public GrupoVeiculo GerandoGrupoDeVeiculo()
        {
            var grupo = new GrupoVeiculo("Monoposto");

            return grupo;
        }
    }
}
