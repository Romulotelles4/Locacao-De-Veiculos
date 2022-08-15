using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloCondutor
{
    public class ServiceCondutor : ServiceBase<Condutor, ValidadorCondutor>
    {
        public ServiceCondutor(IRepositorioCondutor repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(Condutor registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorCliente(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Cliente ja possui condutor!"));

            var existeRegistroPorUsuario = SelecionarPorCpf(registro);

            if (existeRegistroPorUsuario)
                erros.Add(new Error("Campo 'Cpf' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }


        private bool SelecionarPorCliente(Condutor registro)
        {
            IRepositorioCondutor repositorioFuncionario = (IRepositorioCondutor)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarCondutorPorCliente(registro.Cliente.Id);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Cliente.Id == registro.Cliente.Id &&
                   funcionarioEncontrado.Id != registro.Id;
        }

        private bool SelecionarPorCpf(Condutor registro)
        {
            IRepositorioCondutor repositorioFuncionario = (IRepositorioCondutor)repositorio;

            var condutorEncontrado = repositorioFuncionario.SelecionarCondutorPorCpf(registro.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf == registro.Cpf &&
                   condutorEncontrado.Id != registro.Id;
        }

    }
}
