using Autofac;
using Locadora.Aplicacao.ModuloCliente;
using Locadora.Aplicacao.ModuloCondutor;
using Locadora.Aplicacao.ModuloFuncionario;
using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Aplicacao.ModuloPlanoCobranca;
using Locadora.Aplicacao.ModuloTaxa;
using Locadora.Aplicacao.ModuloVeiculo;
using Locadora.Apresentacao.WinForm.ModuloCliente;
using Locadora.Apresentacao.WinForm.ModuloCondutor;
using Locadora.Apresentacao.WinForm.ModuloFuncionario;
using Locadora.Apresentacao.WinForm.ModuloGrupoDeVeiculos;
using Locadora.Apresentacao.WinForm.ModuloPlanoCobranca;
using Locadora.Apresentacao.WinForm.ModuloTaxa;
using Locadora.Apresentacao.WinForm.ModuloVeiculo;
using Locadora.Dominio.ModuloCliente;
using Locadora.Dominio.ModuloCondutor;
using Locadora.Dominio.ModuloFuncionario;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Dominio.ModuloTaxa;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.BancoDados.ModuloCliente;
using Locadora.Infra.BancoDados.ModuloCondutor;
using Locadora.Infra.BancoDados.ModuloFuncionario;
using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using Locadora.Infra.BancoDados.ModuloPlanoCobranca;
using Locadora.Infra.BancoDados.ModuloTaxa;
using Locadora.Infra.BancoDados.ModuloVeiculo;

namespace Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator
{
    public class ServiceLocatorAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioClienteEmBancoDeDados>().As<IRepositorioCliente>();
            builder.RegisterType<ServiceCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioBancoDados>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServiceFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioTaxa>().As<IRepositorioTaxa>();
            builder.RegisterType<ServiceTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculo>().As<IRepositorioGrupoVeiculo>();
            builder.RegisterType<ServiceGrupoVeiculo>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculo>().AsSelf();

            builder.RegisterType<RepositorioVeiculo>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServiceVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioCondutor>().As<IRepositorioCondutor>();
            builder.RegisterType<ServiceCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaBancoDados>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicePlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            container = builder.Build();
        }
        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
