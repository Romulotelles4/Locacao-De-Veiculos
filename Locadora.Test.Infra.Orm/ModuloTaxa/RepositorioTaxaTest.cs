using FluentAssertions;
using Locadora.Dominio.ModuloTaxa;
using Locadora.Infra.Orm.ModuloTaxa;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Test.Infra.Orm.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaTest : RepositorioBaseOrmTest
    {
        RepositorioTaxa repositorio;
        public RepositorioTaxaTest()
        {
            repositorio = new RepositorioTaxa(contextoDadosOrm);
            LimparTabela("TbTaxa");
        }

        [TestMethod]
        public void DeveInserNovaTaxa()
        {
            var NovaTaxa = gerarTaxa();

            repositorio.Inserir(NovaTaxa);

            contextoDadosOrm.GravarDados();

            var taxaInserida = repositorio.SelecionarPorId(NovaTaxa.Id);

            taxaInserida.Should().NotBeNull();
            taxaInserida.Should().Be(NovaTaxa);
        }
        [TestMethod]
        public void DeveEditarTaxa()
        {
            var novaTaxa = gerarTaxa();

            repositorio.Inserir(novaTaxa);

            contextoDadosOrm.GravarDados();

            novaTaxa.Descricao = "Sense of time are running low";
            novaTaxa.TipoDeCalculo = 0;
            novaTaxa.Valor = 2000.00m;

            repositorio.Editar(novaTaxa);

            contextoDadosOrm.GravarDados();


            var taxaEditada = repositorio.SelecionarPorId(novaTaxa.Id);

            taxaEditada.Should().NotBeNull();
            taxaEditada.Should().Be(novaTaxa);
        }
        [TestMethod]
        public void DeveExcluirTaxa()
        {
            var novaTaxa = gerarTaxa();

            repositorio.Inserir(novaTaxa);

            contextoDadosOrm.GravarDados();

            repositorio.Excluir(novaTaxa);

            contextoDadosOrm.GravarDados();

            repositorio.SelecionarPorId(novaTaxa.Id)
                .Should().BeNull();
        }
        [TestMethod]
        public void DeveSelecionarTodos()
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

            contextoDadosOrm.GravarDados();

            var listTaxa = repositorio.SelecionarTodos();

            listTaxa[0].Descricao.Should().Be(novaTaxaUm.Descricao);
            listTaxa[1].Descricao.Should().Be(novaTaxaDois.Descricao);
            listTaxa[2].Descricao.Should().Be(novaTaxaTres.Descricao);

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
