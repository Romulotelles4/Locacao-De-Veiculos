using Locadora.Aplicacao.ModuloCliente;
using Locadora.Aplicacao.ModuloCondutor;
using Locadora.Aplicacao.ModuloDevolucao;
using Locadora.Aplicacao.ModuloFuncionario;
using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Aplicacao.ModuloLocacao;
using Locadora.Aplicacao.ModuloPlanoCobranca;
using Locadora.Aplicacao.ModuloTaxa;
using Locadora.Aplicacao.ModuloVeiculo;
using Locadora.Apresentacao.WinForm.ModuloCliente;
using Locadora.Apresentacao.WinForm.ModuloCondutor;
using Locadora.Apresentacao.WinForm.ModuloDevolucao;
using Locadora.Apresentacao.WinForm.ModuloFuncionario;
using Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos;
using Locadora.Apresentacao.WinForm.ModuloLocacao;
using Locadora.Apresentacao.WinForm.ModuloPlanoCobranca;
using Locadora.Apresentacao.WinForm.ModuloTaxa;
using Locadora.Apresentacao.WinForm.ModuloVeiculo;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Dominio.ModuloDevolucao;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloLocacao;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Dominio.ModuloTaxa;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.Orm.Compartilhado;
using Locadora.Infra.Orm.ModuloCliente;
using Locadora.Infra.Orm.ModuloCondutor;
using Locadora.Infra.Orm.ModuloDevolucao;
using Locadora.Infra.Orm.ModuloFuncionario;
using Locadora.Infra.Orm.ModuloGrupoVeiculo;
using Locadora.Infra.Orm.ModuloLocacao;
using Locadora.Infra.Orm.ModuloPlanoCobranca;
using Locadora.Infra.Orm.ModuloTaxa;
using Locadora.Infra.Orm.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator
{
    internal class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;
        public ServiceLocatorManual()
        {
            InicializarControladores();
        }
        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void InicializarControladores()
        {
            controladores = new Dictionary<string, ControladorBase>();

            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraVeiculoDbContext(connectionString);

            IRepositorioCliente repositorioCliente = new RepositorioCliente(contextoDadosOrm);
            ServiceCliente serviceCliente = new ServiceCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(serviceCliente));


            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(contextoDadosOrm);
            ServiceFuncionario serviceFuncionario = new ServiceFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(serviceFuncionario));

            IRepositorioTaxa repositorioTaxa = new RepositorioTaxa(contextoDadosOrm);
            ServiceTaxa serviceTaxa = new ServiceTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(serviceTaxa));

            IRepositorioGrupoVeiculo repositorioGrupoDeVeiculos = new RepositorioGrupoVeiculo(contextoDadosOrm);
            ServiceGrupoVeiculo serviceGrupoDeVeiculos = new ServiceGrupoVeiculo(repositorioGrupoDeVeiculos, contextoDadosOrm);
            controladores.Add("ControladorGrupoVeiculo", new ControladorGrupoVeiculo(serviceGrupoDeVeiculos));

            IRepositorioPlanoCobranca repositorioPlanoCobranca = new RepositorioPlanoCobranca(contextoDadosOrm);
            ServicePlanoCobranca servicePlanoCobranca = new ServicePlanoCobranca(repositorioPlanoCobranca, contextoDadosOrm);
            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(servicePlanoCobranca, serviceGrupoDeVeiculos));

            IRepositorioVeiculo repositorioVeiculo = new RepositorioVeiculo(contextoDadosOrm);
            ServiceVeiculo serviceVeiculo = new ServiceVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(serviceGrupoDeVeiculos, serviceVeiculo));

            IRepositorioCondutor repositorioCondutor = new RepositorioCondutor(contextoDadosOrm);
            ServiceCondutor servicecondutor = new ServiceCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicecondutor, serviceCliente));

            IRepositorioLocacao repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            ServiceLocacao serviceLocacao = new ServiceLocacao(repositorioLocacao, contextoDadosOrm);
            controladores.Add("ControladorLocacao", new ControladorLocacao(
                serviceLocacao, 
                serviceCliente, 
                servicecondutor, 
                serviceFuncionario, 
                serviceGrupoDeVeiculos, 
                servicePlanoCobranca, 
                serviceVeiculo, 
                serviceTaxa));

            IRepositorioDevolucao repositorioDevolucao = new RepositorioDevolucao(contextoDadosOrm);
            ServiceDevolucao serviceDevolucao = new ServiceDevolucao(repositorioDevolucao, contextoDadosOrm);
            controladores.Add("ControladorDevolucao", new ControladorDevolucao(serviceDevolucao, serviceLocacao));
        }
    }
}
