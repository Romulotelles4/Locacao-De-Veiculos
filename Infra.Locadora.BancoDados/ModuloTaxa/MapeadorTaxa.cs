using Locadora.Dominio.ModuloTaxa;
using Locadora.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("VALOR", registro.Valor);
            comando.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            comando.Parameters.AddWithValue("ENUM_TIPODECALCULO", registro.TipoDeCalculo);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["ID"].ToString());

            decimal valor = Convert.ToDecimal(leitorRegistro["VALOR"]);

            string descricao = Convert.ToString(leitorRegistro["DESCRICAO"]);

            int tipoDeCalculo = Convert.ToInt32(leitorRegistro["ENUM_TIPODECALCULO"]);

            var Taxa = new Taxa
            {
                Id = id,
                Valor = valor,
                Descricao = descricao,
                TipoDeCalculo = (TipoDeCalculo)tipoDeCalculo
            };

            return Taxa;


        }
    }
}
