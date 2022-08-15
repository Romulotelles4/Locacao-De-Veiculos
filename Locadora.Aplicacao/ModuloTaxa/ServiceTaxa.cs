using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloTaxa;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloTaxa
{
    public class ServiceTaxa : ServiceBase<Taxa, ValidadorTaxa>
    {
        public ServiceTaxa(IRepositorioTaxa repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(Taxa registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorDescricao(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Campo 'Descricao' duplicado"));


            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorDescricao(Taxa registro)
        {
            IRepositorioTaxa repositorioFuncionario = (IRepositorioTaxa)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarTaxaPorDescricao(registro.Descricao);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Descricao == registro.Descricao &&
                   funcionarioEncontrado.Id != registro.Id;
        }
    }
}
