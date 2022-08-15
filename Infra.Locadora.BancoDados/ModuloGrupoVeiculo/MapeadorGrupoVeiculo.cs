using Locadora.Dominio.ModuloGrupoDeVeiculo;
using Locadora.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculo : MapeadorBase<GrupoVeiculo>
    {
        public override void ConfigurarParametros(GrupoVeiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public override GrupoVeiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["GRUPOVEICULO_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["GRUPOVEICULO_NOME"]);

            var grupoDeVeiculo = new GrupoVeiculo()
            {
                Id = id,
                Nome = nome
            };

            return grupoDeVeiculo;
        }
    }
}

