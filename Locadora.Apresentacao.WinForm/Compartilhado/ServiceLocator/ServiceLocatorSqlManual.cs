using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator
{
    public class ServiceLocatorSqlManual
    {
        private Dictionary<string, ControladorBase> controladores;
        public ServiceLocatorSqlManual()
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

            //IRepositorioCliente repositorioCliente = new RepositorioClienteEmBancoDeDados();
            //ServiceCliente serviceCliente = new ServiceCliente(repositorioCliente);
            //controladores.Add("ControladorCliente", new ControladorCliente(serviceCliente));

            //IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioBancoDados();
            //ServiceFuncionario serviceFuncionario = new ServiceFuncionario(repositorioFuncionario);
            //controladores.Add("ControladorFuncionario", new ControladorFuncionario(serviceFuncionario));

            //IRepositorioTaxa repositorioTaxa = new RepositorioTaxa();
            //ServiceTaxa serviceTaxa = new ServiceTaxa(repositorioTaxa);
            //controladores.Add("Taxa", new ControladorTaxa(serviceTaxa));

            //IRepositorioGrupoVeiculo repositorioGrupoDeVeiculos = new RepositorioGrupoVeiculo();
            //ServiceGrupoVeiculo serviceGrupoDeVeiculos = new ServiceGrupoVeiculo(repositorioGrupoDeVeiculos);
            //controladores.Add("Grupo Veiculos", new ControladorGrupoVeiculo(serviceGrupoDeVeiculos));

            //IRepositorioVeiculo repositorioVeiculo = new RepositorioVeiculo();
            //ServiceVeiculo serviceVeiculo = new ServiceVeiculo(repositorioVeiculo);
            //controladores.Add("Veiculos", new ControladorVeiculo(serviceGrupoDeVeiculos, serviceVeiculo));

            //IRepositorioCondutor repositorioCondutor = new RepositorioCondutor();
            //ServiceCondutor servicecondutor = new ServiceCondutor(repositorioCondutor);
            //controladores.Add("Condutores", new ControladorCondutor(servicecondutor, serviceCliente));
        }
    }
}
