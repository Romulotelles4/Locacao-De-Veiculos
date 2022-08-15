using FluentAssertions;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloLocacao;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Dominio.ModuloTaxa;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.Orm.ModuloCliente;
using Locadora.Infra.Orm.ModuloCondutor;
using Locadora.Infra.Orm.ModuloFuncionario;
using Locadora.Infra.Orm.ModuloGrupoVeiculo;
using Locadora.Infra.Orm.ModuloLocacao;
using Locadora.Infra.Orm.ModuloPlanoCobranca;
using Locadora.Infra.Orm.ModuloTaxa;
using Locadora.Infra.Orm.ModuloVeiculo;
using Locadora.Test.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Test.Infra.Orm.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoOrmTest : RepositorioBaseOrmTest
    {
        private IRepositorioLocacao repositorioLocacao;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioCondutor repositorioCondutor;
        private IRepositorioGrupoVeiculo repositorioGrupoVeiculo;
        private IRepositorioVeiculo repositorioVeiculo;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IRepositorioTaxa repositorioTaxa;
        public RepositorioLocacaoOrmTest()
        {
            repositorioLocacao= new RepositorioLocacaoOrm(contextoDadosOrm);
            repositorioFuncionario= new RepositorioFuncionario(contextoDadosOrm);
            repositorioCliente= new RepositorioCliente(contextoDadosOrm);
            repositorioCondutor= new RepositorioCondutor(contextoDadosOrm);
            repositorioGrupoVeiculo= new RepositorioGrupoVeiculo(contextoDadosOrm);
            repositorioVeiculo= new RepositorioVeiculo(contextoDadosOrm);
            repositorioPlanoCobranca= new RepositorioPlanoCobranca(contextoDadosOrm);
            repositorioTaxa= new RepositorioTaxa(contextoDadosOrm);
        }

        [TestMethod]
        public void Deve_inserir_nova_locacao()
        {
            //arrange
            var locacoes = NovaLocacao();

            //action
            repositorioLocacao.Inserir(locacoes[0]);

            contextoDadosOrm.GravarDados();

            //assert
            var locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacoes[0].Id);

            locacaoEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_Editar_locacao()
        {
            //arrange
            var locacoes = NovaLocacao();

            repositorioLocacao.Inserir(locacoes[0]);

            contextoDadosOrm.GravarDados();

            //action
            locacoes[0].Status = EnumLocacaoStatus.Finalizada;


            //assert
            var locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacoes[0].Id);

            locacaoEncontrada.Should().NotBeNull();
            Assert.AreEqual(locacoes[0].Status, locacaoEncontrada.Status);
        }

        [TestMethod]
        public void Deve_Excluir_locacao()
        {
            //arrange
            var locacoes = NovaLocacao();

            repositorioLocacao.Inserir(locacoes[0]);

            contextoDadosOrm.GravarDados();
            
            //action
            var locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacoes[0].Id);

            repositorioLocacao.Excluir(locacaoEncontrada);

            contextoDadosOrm.GravarDados();

            //assert
            var locacaoExcluida = repositorioLocacao.SelecionarPorId(locacaoEncontrada.Id);

            locacaoExcluida.Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_locacao_por_id()
        {
            //arrange
            var locacoes = NovaLocacao();

            repositorioLocacao.Inserir(locacoes[0]);

            contextoDadosOrm.GravarDados();

            //action
            var locacaoEncontrada = repositorioLocacao.SelecionarPorId(locacoes[0].Id);

            //Assert
            locacaoEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_locacoes()
        {
            //arrange
            var locacoes = NovaLocacao();

            foreach(var item in locacoes)
                repositorioLocacao.Inserir(item);

            contextoDadosOrm.GravarDados();

            //action
            var locacoesEncontradas = repositorioLocacao.SelecionarTodos();

            //assert
            locacoesEncontradas.Should().NotBeNull();
            locacoesEncontradas.Count.Should().Be(2);
        }

        #region Métodos privados
        /// <summary>
        /// Todos os métodos contidos na nova locação deve conter uma lista com quantidades iguais de objetos
        /// Retorna Lista de locações com todas as suas dependencias ja inseridas no banco
        /// </summary>
        /// <returns>List<Locacao></returns>
        private List<Locacao> NovaLocacao()
        {
            var Taxas = gerarTaxa();
            
            var Funcionarios = NovoFuncionario();
            
            var GrupoVeiculos = GerandoGrupoVeiculo();
            
            var Clientes = NovoCliente();
            
            var Condutor = NovoCondutor(Clientes);
            
            var Veiculo = GerandoVeiculo(GrupoVeiculos);
            
            var PlanoCobranca = GerandoPlanoCobranca(GrupoVeiculos);

            List<Locacao> Locacoes = new List<Locacao>()
            {
                new Locacao {
                    QuilometragemInicial = 1.00m,
                    DataInicialLocacao = DateTime.Now.Date,
                    DataPrevistaDevolucao = DateTime.Now.Date.AddDays(5),
                    Status = EnumLocacaoStatus.Aberta
                    },
                new Locacao {
                    QuilometragemInicial = 2.00m,
                    DataInicialLocacao = DateTime.Now.Date.AddDays(2),
                    DataPrevistaDevolucao = DateTime.Now.Date.AddDays(8),
                    Status = EnumLocacaoStatus.Finalizada
                    }
            };

            for (int i = 0; i < Locacoes.Count; i++)
            {
                Locacoes[i].AddTaxas(Taxas[i]);
                Locacoes[i].AddCliente(Clientes[i]);
                Locacoes[i].AddCondutor(Condutor[i]);
                Locacoes[i].AddFuncionario(Funcionarios[i]);
                Locacoes[i].AddGrupoVeiculo(GrupoVeiculos[i]);
                Locacoes[i].AddVeiculo(Veiculo[i]);
                Locacoes[i].AddPlanoCobranca(PlanoCobranca[i]);
            }

            return Locacoes;
        }
        private List<PlanoCobranca> GerandoPlanoCobranca(List<GrupoVeiculo> GrupoVeiculos)
        {
            List<PlanoCobranca> planosCobranca = new List<PlanoCobranca> 
            {
                new PlanoCobranca
                    {
                        ControladoDiaria = 1.00m,
                        ControladoLimiteKm = 1.00m,
                        ControladoPorKm = 1.00m,
                        DiarioDiaria = 1.00m,
                        DiarioPorKm = 1.00m,
                        LivreDiaria = 1.00m
                    },
                new PlanoCobranca
                    {
                        ControladoDiaria = 2.00m,
                        ControladoLimiteKm = 2.00m,
                        ControladoPorKm = 2.00m,
                        DiarioDiaria = 2.00m,
                        DiarioPorKm = 2.00m,
                        LivreDiaria = 2.00m
                    }
            };

            for(int i = 0; i < planosCobranca.Count; i++)
                planosCobranca[i].GrupoVeiculo = GrupoVeiculos[i];

            foreach(var item in planosCobranca)
                repositorioPlanoCobranca.Inserir(item);

            contextoDadosOrm.GravarDados();

            return planosCobranca;
        }
        private List<Veiculo> GerandoVeiculo(List<GrupoVeiculo> GrupoVeiculos)
        {
            List<Veiculo> veiculos = new List<Veiculo>
            {
                new Veiculo("BMW Z4", "40440 - DV", "BMW", "Azul", 30m, 100m, EnumTipoDeCombustivel.Gasolina),
                new Veiculo("Uno", "abc-1234", "Fiat", "Prata", 80m, 10000m, EnumTipoDeCombustivel.Gasolina)
            };

            foreach(var item in veiculos)
                item.Foto = new byte[] { 1, 2, 3 };
            
            for(int i = 0; i < veiculos.Count; i++)
                veiculos[i].GrupoDeVeiculo = GrupoVeiculos[i];

            foreach(var item in veiculos)
                repositorioVeiculo.Inserir(item);

            contextoDadosOrm.GravarDados();

            return veiculos;
        }
        private List<Condutor> NovoCondutor(List<Cliente> Clientes)
        {
            List<Condutor> Condutores = new List<Condutor>
            {
                new Condutor
                {
                    Nome = "Joao condutor",
                    Cpf = "12345678930",
                    Cnh = "98765432100",
                    Endereco = "Rua teste",
                    Email = "teste@teste.com",
                    Telefone = "49999999999"
                },
                new Condutor
                {
                    Nome = "Marcos condutor",
                    Cpf = "00011122233",
                    Cnh = "9999888877",
                    Endereco = "Rua do marcos",
                    Email = "teste@teste.com",
                    Telefone = "49988885555"
                }
            };

            for (int i = 0; i < Condutores.Count; i++)
            {
                Condutores[i].Cliente = Clientes[i];
                Condutores[i].ClienteId = Clientes[i].Id;
            }
            foreach (var item in Condutores)
                repositorioCondutor.Inserir(item);

            contextoDadosOrm.GravarDados();

            return Condutores;
        }
        private List<GrupoVeiculo> GerandoGrupoVeiculo()
        {
            List<GrupoVeiculo> GrupoVeiculos = new List<GrupoVeiculo>
            {
                new GrupoVeiculo("Suv"),
                new GrupoVeiculo("Compacto")
            };

            foreach (var item in GrupoVeiculos)
                repositorioGrupoVeiculo.Inserir(item);

            contextoDadosOrm.GravarDados();

            return GrupoVeiculos;
        }
        private List<Funcionario> NovoFuncionario()
        {
            List<Funcionario> Funcionarios = new List<Funcionario>
            {
                new Funcionario("Master", "Admin1", "Admin1", new DateTime(2022, 01, 01), false, 5000.00m),
                new Funcionario("Secretário", "secreta", "secretapassw", new DateTime(2020, 01, 01), false, 2000.00m)
            };

            foreach (var item in Funcionarios)
                repositorioFuncionario.Inserir(item);

            contextoDadosOrm.GravarDados();

            return Funcionarios;
        }
        private List<Cliente> NovoCliente()
        {
            List<Cliente> Clientes = new List<Cliente>
            {
                new Cliente("Bruno", "55663", "1256345", "2348888", "lages sc", "Bruno@hotmail.com", "4999988938", true),
                new Cliente("Marcos", "01234567800", "1234567890001", "01234567890", "lages sc", "marcos@marcos.com", "4999988938", true)
            };

            foreach (var item in Clientes)
                repositorioCliente.Inserir(item);

            contextoDadosOrm.GravarDados();

            return Clientes;
        }
        private List<Taxa> gerarTaxa()
        {
            List<Taxa> Taxas = new List<Taxa>()
            {
                new Taxa
                    {
                        Descricao = "Cadeirinha infantil",
                        Valor = 10.00m,
                        TipoDeCalculo = TipoDeCalculo.CalculoDiario
                    },
                 new Taxa
                    {
                        Descricao = "GPS",
                        Valor = 20.00m,
                        TipoDeCalculo = TipoDeCalculo.CalculoFixo
                    }
            };

            foreach (var item in Taxas)
                repositorioTaxa.Inserir(item);

            contextoDadosOrm.GravarDados();
            
            return Taxas;
        }
        #endregion
    }
}
