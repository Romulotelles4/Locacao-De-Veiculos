using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.ModuloVeiculo
{
    public class ServiceVeiculo : ServiceBase<Veiculo, ValidadorVeiculo>
    {
        public ServiceVeiculo(IRepositorioVeiculo repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {



        }

        public override Result ExisteCamposDuplicados(Veiculo registro)
        {
            List<Error> erros = new List<Error>();

            var resultado = SelecionarPorDescricao(registro);

            if (resultado)
            {
                erros.Add(new Error("Placa do Veiculo Duplicada"));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorDescricao(Veiculo registro)
        {
            IRepositorioVeiculo repositorioFuncionario = (IRepositorioVeiculo)repositorio;

            var funcionarioEncontrado = repositorioFuncionario.SelecionarVeiculoPorPlaca(registro.Placa);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Placa == registro.Placa &&
                   funcionarioEncontrado.Id != registro.Id;
        }
    }
}
