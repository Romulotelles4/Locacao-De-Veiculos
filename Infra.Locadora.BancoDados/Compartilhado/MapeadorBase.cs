using Locadora.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T registro, SqlCommand comando);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }
}
