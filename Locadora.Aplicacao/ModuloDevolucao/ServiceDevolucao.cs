using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Aplicacao.ModuloDevolucao
{
    public class ServiceDevolucao : ServiceBase<Devolucao, ValidadorDevolucao>
    {
        public ServiceDevolucao(IRepositorioBase<Devolucao> repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result ExisteCamposDuplicados(Devolucao registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorLocacao(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("'Locacao' já possuí uma devolução"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorLocacao(Devolucao registro)
        {
            var repositorioDevolucao = (IRepositorioDevolucao)repositorio;

            var resultado = repositorioDevolucao.SelecionarPorDevolucao(registro);

            if (resultado != null)
                return true;

            return false;
        }
    }
}
