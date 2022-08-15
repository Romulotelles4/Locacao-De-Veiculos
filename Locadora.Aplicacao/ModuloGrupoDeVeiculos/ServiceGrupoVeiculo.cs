using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloGrupoDeVeiculos
{
    public class ServiceGrupoVeiculo : ServiceBase<GrupoVeiculo, ValidadorGrupoVeiculo>
    {
        public ServiceGrupoVeiculo(IRepositorioGrupoVeiculo repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {

        }

        public override Result ExisteCamposDuplicados(GrupoVeiculo registro)
        {

            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorNome(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Campo 'Descricao' duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorNome(GrupoVeiculo registro)
        {
            IRepositorioGrupoVeiculo repositorioFuncionario = (IRepositorioGrupoVeiculo)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarGrupoVeiculoPorNome(registro.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == registro.Nome &&
                   funcionarioEncontrado.Id != registro.Id;
        }
    }
}
