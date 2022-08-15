using FluentAssertions;
using Locadora.Dominio.ModuloTaxa;
using Locadora.Infra.BancoDados.ModuloTaxa;
using Locadora.Test.Infra.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaBancoDadosTest : RepositorioBaseTest
    {
        private RepositorioTaxa repositorio;

        protected override string NomeTabela => "TbTaxa";

        public RepositorioTaxaBancoDadosTest()
        {
            this.repositorio = new RepositorioTaxa();
        }

        [TestMethod]
        public void Deve_Inserir_Taxa()
        {
            var NovaTaxa = gerarTaxa();

            repositorio.Inserir(NovaTaxa);

            var taxaInserida = repositorio.SelecionarPorId(NovaTaxa.Id);

            taxaInserida.Should().NotBeNull();
            taxaInserida.Should().Be(NovaTaxa);
        }

        [TestMethod]
        public void Deve_Editar_Taxa()
        {
            var novaTaxa = gerarTaxa();

            repositorio.Inserir(novaTaxa);

            novaTaxa.Descricao = "Sense of time are running low";
            novaTaxa.TipoDeCalculo = 0;
            novaTaxa.Valor = 2000.00m;

            repositorio.Editar(novaTaxa);

            var taxaEditada = repositorio.SelecionarPorId(novaTaxa.Id);

            taxaEditada.Should().NotBeNull();
            taxaEditada.Should().Be(novaTaxa);

        }

        [TestMethod]
        public void Deve_Excluir_Taxa()
        {
            var novaTaxa = gerarTaxa();

            repositorio.Inserir(novaTaxa);
            repositorio.Excluir(novaTaxa);

            repositorio.SelecionarPorId(novaTaxa.Id)
                .Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Por_Id()
        {
            var novaTaxa = gerarTaxa();

            repositorio.Inserir(novaTaxa);

            repositorio.SelecionarPorId(novaTaxa.Id)
                .Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Todas_Taxas()
        {
            var novaTaxaUm = gerarTaxa();

            var novaTaxaDois = new Taxa();

            novaTaxaDois.Descricao = "aaaaaa";
            novaTaxaDois.Valor = 1000;
            novaTaxaDois.TipoDeCalculo = TipoDeCalculo.CalculoDiario;

            var novaTaxaTres = new Taxa();
            novaTaxaTres.Descricao = "ggggg";
            novaTaxaTres.Valor = 2000;
            novaTaxaTres.TipoDeCalculo = TipoDeCalculo.CalculoFixo;

            repositorio.Inserir(novaTaxaUm);
            repositorio.Inserir(novaTaxaDois);
            repositorio.Inserir(novaTaxaTres);

            var listTaxa = repositorio.SelecionarTodos();

            listTaxa[0].Descricao.Should().Be(novaTaxaUm.Descricao);
            listTaxa[1].Descricao.Should().Be(novaTaxaDois.Descricao);
            listTaxa[2].Descricao.Should().Be(novaTaxaTres.Descricao);
            LimparTabela("TbTaxa");
        }

        //[TestMethod]
        //public void Nao_deve_Inserir_Taxa_com_descricao_duplicada()
        //{
        //    //range
        //    var NovaTaxa = gerarTaxa();
        //    var taxa2 = gerarTaxa();

        //    //action
        //    repositorio.Inserir(NovaTaxa);
        //    repositorio.Inserir(taxa2);

        //    var taxaInserida = repositorio.SelecionarTodos();

        //    //Assert
        //    Assert.AreEqual(1, taxaInserida.Count);
        //}

        [TestMethod]
        public void Nao_deve_editar_Taxa_com_descricao_duplicada()
        {
            ////range
            //var taxa1 = new Taxa(10.00m, "cadeirinha", TipoDeCalculo.CalculoDiario);
            //var taxa2 = new Taxa(15.00m, "GPS", TipoDeCalculo.CalculoFixo);

            ////action
            //repositorio.Inserir(taxa1);
            //repositorio.Inserir(taxa2);

            //taxa1.Descricao = "GPS";

            //var taxaInserida = repositorio.Editar(taxa1);

            ////Assert
            //Assert.AreEqual(false, taxaInserida.IsValid);
        }

        private Taxa gerarTaxa()
        {
            Taxa taxa = new Taxa();

            taxa.Descricao = "Ar condicionado Incluso";
            taxa.TipoDeCalculo = TipoDeCalculo.CalculoFixo;
            taxa.Valor = 100;

            return taxa;
        }
    }
}
