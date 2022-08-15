using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using Locadora.Dominio.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Aplicacao.Compartilhado
{
    public abstract class ServiceBase<T, TValidador>
        where T : EntidadeBase<T>
         where TValidador : AbstractValidator<T>, new()
    {
        protected IRepositorioBase<T> repositorio;

        private IContextoPersistencia contextoPersistencia;
        public ServiceBase(IRepositorioBase<T> repositorio, IContextoPersistencia contexto)
        {
            this.repositorio = repositorio;
            contextoPersistencia = contexto;

        }

        public Result<T> Inserir(T registro)
        {
            Log.Logger.Debug("Tentando inserir {registro}... {@f}", registro.GetType().Name, registro.Id);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o {ObjetoNome} {RegistroId} - {Motivo}",
                       registro.GetType().Name, registro.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorio.Inserir(registro);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("{ObjetoNome} {registroId} inserido com sucesso", registro.GetType().Name, registro.Id);

                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o "+registro.GetType().Name;

                Log.Logger.Error(ex, msgErro + "{RegistroId}", registro.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<T> Editar(T registro)
        {
            Log.Logger.Debug("Tentando editar registro... {@f}", registro);

            Result resultadoValidacao = ValidarRegistro(registro);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o registro {RegistroId} - {Motivo}",
                       registro.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorio.Editar(registro);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Registro {RegistroId} editado com sucesso", registro.Id);

                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o registro";

                Log.Logger.Error(ex, msgErro + "{RegistroId}", registro.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(T registro)
        {
            Log.Logger.Debug("Tentando excluir registro... {@f}", registro);

            try
            {
                repositorio.Excluir(registro);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Registro {RegistroId} excluído com sucesso", registro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o registro";

                Log.Logger.Error(ex, msgErro + "{RegistroId}", registro.Id);

                return Result.Fail(msgErro);
            }
        }

        public virtual Result<List<T>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorio.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os registros.";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<T> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorio.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o registro";

                Log.Logger.Error(ex, msgErro + "{RegistroId}", id);

                return Result.Fail(msgErro);
            }
        }

        protected virtual ValidationResult GerarErroRepetido(string mensagem)
        {
            ValidationResult erro = new ValidationResult();

            erro.Errors.Add(new ValidationFailure("", mensagem));

            return erro;
        }

        private Result ValidarRegistro(T registro)
        {
            var validador = new TValidador();

            var resultado = validador.Validate(registro);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultado.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            Result registroDuplicado = ExisteCamposDuplicados(registro);

            foreach (var item in registroDuplicado.Errors) //FluentValidation            
                erros.Add(new Error(item.Message));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public abstract Result ExisteCamposDuplicados(T registro);
    }
}
