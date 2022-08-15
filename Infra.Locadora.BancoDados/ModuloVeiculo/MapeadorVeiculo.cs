using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloVeiculo;
using Locadora.Infra.BancoDados.Compartilhado;
using Locadora.Infra.BancoDados.ModuloGrupoVeiculo;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {

        MapeadorGrupoVeiculo mapeadorGrupoDeVeiculo;

        public MapeadorVeiculo()
        {
            this.mapeadorGrupoDeVeiculo = new MapeadorGrupoVeiculo();
        }

        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorrido);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", registro.CapacidadeTanque);
            comando.Parameters.AddWithValue("ENUMTIPODECOMBUSTIVEL", registro.TipoDeCombustivel);
            comando.Parameters.AddWithValue("GRUPOVEICULO_ID", registro.GrupoDeVeiculo.Id);
            comando.Parameters.AddWithValue("FOTO", registro.Foto);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["VEICULO_ID"].ToString());

            string modelo = Convert.ToString(leitorRegistro["MODELO"]);

            string marca = Convert.ToString(leitorRegistro["MARCA"]);

            string placa = Convert.ToString(leitorRegistro["PLACA"]);

            string cor = Convert.ToString(leitorRegistro["COR"]);

            decimal kmPercorrido = Convert.ToDecimal(leitorRegistro["KMPERCORRIDO"]);

            decimal capacidadeTanque = Convert.ToDecimal(leitorRegistro["CAPACIDADETANQUE"]);

            byte[] foto = (byte[])(leitorRegistro["FOTO"]);

            EnumTipoDeCombustivel tipoDeCombustivel = (EnumTipoDeCombustivel)Convert.ToInt32(leitorRegistro["ENUMTIPODECOMBUSTIVEL"]);

            var grupoVeiculo = mapeadorGrupoDeVeiculo.ConverterRegistro(leitorRegistro);

            var Veiculo = new Veiculo()
            {
                Id = id,
                Modelo = modelo,
                Marca = marca,
                Placa = placa,
                Cor = cor,
                KmPercorrido = kmPercorrido,
                CapacidadeTanque = capacidadeTanque,
                TipoDeCombustivel = tipoDeCombustivel,
                GrupoDeVeiculo = grupoVeiculo,
                Foto = foto

            };

            return Veiculo;


        }
    }
}
