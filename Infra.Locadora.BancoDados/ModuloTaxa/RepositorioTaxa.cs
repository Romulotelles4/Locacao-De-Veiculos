using Locadora.Dominio.ModuloTaxa;
using Locadora.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBase<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir => @"INSERT INTO [TbTaxa]
                                                   (
                                                    [ID],
                                                    [VALOR],
                                                    [DESCRICAO],
                                                    [ENUM_TIPODECALCULO]
                                                   )
                                                   VALUES
                                                    (
                                                     @ID,
                                                     @VALOR,
                                                     @DESCRICAO,
                                                     @ENUM_TIPODECALCULO
                                                    )
                                                  ";




        protected override string sqlEditar => @"UPDATE [TbTaxa]
                                                   SET
                                                     [VALOR]=@VALOR,
                                                     [DESCRICAO]=@DESCRICAO,
                                                     [ENUM_TIPODECALCULO]=@ENUM_TIPODECALCULO
                                                   WHERE
                                                     [ID]=@ID";
        protected override string sqlExcluir => @"DELETE FROM [TbTaxa]
                                                    WHERE
                                                       [ID]=@ID";
        protected override string sqlSelecionarPorId => @"SELECT * FROM [TbTaxa]
                                                               WHERE
                                                                [ID]=@ID";

        protected override string sqlSelecionarTodos => @"SELECT * FROM [TbTaxa]";

        protected string sqlSelecionarPorDescricao =>
            @"SELECT * FROM [TbTaxa]
                           WHERE
                           [DESCRICAO] = @DESCRICAO";

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}
