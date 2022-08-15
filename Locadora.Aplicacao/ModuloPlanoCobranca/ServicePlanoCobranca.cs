using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloPlanoCobranca;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloPlanoCobranca
{
    public class ServicePlanoCobranca : ServiceBase<PlanoCobranca, ValidadorPlanoCobranca>
    {
        public ServicePlanoCobranca(IRepositorioPlanoCobranca repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(PlanoCobranca registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorGrupoVeiculo(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("Campo 'Grupo de Veículo' ja possui 'Plano de Cobrança' vinculado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorGrupoVeiculo(PlanoCobranca registro)
        {
            IRepositorioPlanoCobranca repositorioFuncionario = (IRepositorioPlanoCobranca)repositorio;

            var grupoVeiculoEncontrado = repositorioFuncionario.SelecionarPlanoCobrancaPorGrupoVeiculo(registro.GrupoVeiculo);

            return grupoVeiculoEncontrado != null &&
                   grupoVeiculoEncontrado.GrupoVeiculo.Nome == registro.GrupoVeiculo.Nome &&
                   grupoVeiculoEncontrado.GrupoVeiculo.Id != registro.GrupoVeiculo.Id;
        }
    }
}
