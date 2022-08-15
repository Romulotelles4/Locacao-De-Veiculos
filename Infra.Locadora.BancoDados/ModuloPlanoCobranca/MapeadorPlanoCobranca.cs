using Locadora.Dominio.ModuloPlanoCobranca;
using Locadora.Infra.BancoDados.Compartilhado;
using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        MapeadorGrupoVeiculo mapeador;

        public MapeadorPlanoCobranca()
        {
            mapeador = new MapeadorGrupoVeiculo();
        }
        public override void ConfigurarParametros(PlanoCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPO_VEICULO_ID", registro.GrupoVeiculo.Id);
            comando.Parameters.AddWithValue("DIARIO_DIARIA", registro.DiarioDiaria);
            comando.Parameters.AddWithValue("DIARIO_POR_KM", registro.DiarioPorKm);
            comando.Parameters.AddWithValue("LIVRE_DIARIA", registro.LivreDiaria);
            comando.Parameters.AddWithValue("CONTROLADO_DIARIA", registro.ControladoDiaria);
            comando.Parameters.AddWithValue("CONTROLADO_POR_KM", registro.ControladoPorKm);
            comando.Parameters.AddWithValue("CONTROLADO_LIMITE_KM", registro.ControladoLimiteKm);
        }

        public override PlanoCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["PLANOCOBRANCA_ID"].ToString());
            var grupoVeiculo = mapeador.ConverterRegistro(leitorRegistro);
            decimal diarioValorDiario = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_DIARIO_DIARIA"]);
            decimal diarioValorPorKm = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_DIARIOR_POR_KM"]);
            decimal livreValorDiario = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_LIVRE_DIARIA"]);
            decimal controladoValorDiario = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_CONTROLADO_DIARIA"]);
            decimal controladoValorPorKm = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_CONTROLADO_POR_KM"]);
            decimal controladoLimiteKm = Convert.ToDecimal(leitorRegistro["PLANOCOBRANCA_CONTROLADO_LIMITE_KM"]);

            var planoCobranca = new PlanoCobranca
            {

                Id = id,
                GrupoVeiculo = grupoVeiculo,
                DiarioDiaria = diarioValorDiario,
                DiarioPorKm = diarioValorPorKm,
                LivreDiaria= livreValorDiario,
                ControladoDiaria = controladoValorDiario,
                ControladoPorKm = controladoValorPorKm,
                ControladoLimiteKm = controladoLimiteKm


            };
            return planoCobranca;


        }
    }
}
