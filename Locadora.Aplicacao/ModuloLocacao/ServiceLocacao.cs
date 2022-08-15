using FluentResults;
using Locadora.Aplicacao.Compartilhado;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Aplicacao.ModuloLocacao
{
    public class ServiceLocacao : ServiceBase<Locacao, ValidadorLocacao>
    {
        public ServiceLocacao(IRepositorioBase<Locacao> repositorio, IContextoPersistencia contexto) : base(repositorio, contexto)
        {
        }

        public override Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                var repositorioLocacao = (IRepositorioLocacao)repositorio;
                return Result.Ok(repositorioLocacao.SelecionarTodos(true));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os registros.";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarPorStatus(EnumLocacaoStatus statusLocacao)
        {
            try
            {
                var repositorioLocacao = (IRepositorioLocacao)repositorio;
                return Result.Ok(repositorioLocacao.SelecionarPorStatus(statusLocacao));
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar os registros pelo status {statusLocacao}.";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public override Result ExisteCamposDuplicados(Locacao registro)
        {
            List<Error> erros = new List<Error>();

            var existeRegistroPorNome = SelecionarPorCondutor(registro);

            if (existeRegistroPorNome)
                erros.Add(new Error("'Condutor' já vinculado a uma 'Locação' em aberto!"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool SelecionarPorCondutor(Locacao registro)
        {
            var repositorioLocacao = (IRepositorioLocacao)repositorio;

            var locacaoEncontrada = repositorioLocacao.SelecionarPorCondutor(registro.Condutor);

            return locacaoEncontrada != null &&
                   locacaoEncontrada.Condutor.Id != registro.Condutor.Id;
        }
    }
}
