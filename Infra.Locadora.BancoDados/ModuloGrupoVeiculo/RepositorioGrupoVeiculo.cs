using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculo : RepositorioBase<GrupoVeiculo, MapeadorGrupoVeiculo>, IRepositorioGrupoVeiculo
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULO]
                (
                    ID,
                    NOME
                )
                VALUES
                (
                    @ID,
                    @NOME
                )";
        protected override string sqlEditar =>
                @"UPDATE [TBGRUPOVEICULO]
                    SET
                        NOME=@NOME
                    WHERE
                        [ID]=@ID";
        protected override string sqlExcluir =>
                @"DELETE [TBGRUPOVEICULO]
                    WHERE
                        [ID]=@ID";
        protected override string sqlSelecionarPorId =>
                @"SELECT 
                        ID AS GRUPOVEICULO_ID,
                        NOME AS GRUPOVEICULO_NOME
                    FROM [TBGRUPOVEICULO]
                    WHERE
                        [ID]=@ID";
        protected override string sqlSelecionarTodos =>
                @"SELECT 
                    ID AS GRUPOVEICULO_ID,
                    NOME AS GRUPOVEICULO_NOME
                    FROM [TBGRUPOVEICULO]";

        protected string sqlSelecionarPorNome =>
                @"SELECT * FROM [TBGRUPOVEICULO]
                       WHERE
                           [NOME]=@NOME";

        public GrupoVeiculo SelecionarGrupoVeiculoPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}
