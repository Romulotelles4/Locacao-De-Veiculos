using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCliente;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloCliente
{
    public class ServiceCliente : ServiceBase<Cliente, ValidadorCliente>
    {
        public ServiceCliente(IRepositorioCliente repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(Cliente registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorCpf(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Campo 'Cpf' duplicado"));

            var existeRegistroPorUsuario = SelecionarPorCnpj(registro);

            if (existeRegistroPorUsuario)
                erros.Add(new Error("Campos 'Cnpj' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorCnpj(Cliente registro)
        {
            IRepositorioCliente repositorioCliente = (IRepositorioCliente)repositorio;

            var funcionarioEncontrado = repositorioCliente.SelecionarClientePorCnpj(registro.Cnpj);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Cnpj == registro.Cnpj &&
                   funcionarioEncontrado.Id != registro.Id;
        }

        private bool SelecionarPorCpf(Cliente registro)
        {
            IRepositorioCliente repositorioCliente = (IRepositorioCliente)repositorio;

            var funcionarioEncontrado = repositorioCliente.SelecionarClientePorCpf(registro.Cpf);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Cpf == registro.Cpf &&
                   funcionarioEncontrado.Id != registro.Id;
        }
    }
}
