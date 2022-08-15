using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloFuncionario
{
    public class ServiceFuncionario : ServiceBase<Funcionario, ValidadorFuncionario>
    {
        public ServiceFuncionario(IRepositorioFuncionario repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(Funcionario registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorNome(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Campo 'Nome' duplicado"));

            var existeRegistroPorUsuario = SelecionarPorUsuario(registro);

            if (existeRegistroPorUsuario)
                erros.Add(new Error("Campos 'Login' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorNome(Funcionario registro)
        {
            IRepositorioFuncionario repositorioFuncionario = (IRepositorioFuncionario)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(registro.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == registro.Nome &&
                   funcionarioEncontrado.Id != registro.Id;
        }

        private bool SelecionarPorUsuario(Funcionario registro)
        {
            IRepositorioFuncionario repositorioFuncionario = (IRepositorioFuncionario)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorUsuario(registro.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == registro.Login &&
                   funcionarioEncontrado.Id != registro.Id;
        }
    }
}
