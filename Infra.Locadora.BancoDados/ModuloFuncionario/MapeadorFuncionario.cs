using Locadora.Dominio.ModuloFuncionario;
using Locadora.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora.Infra.BancoDados.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("LOGIN", registro.Login);
            comando.Parameters.AddWithValue("SENHA", registro.Senha);
            comando.Parameters.AddWithValue("DATAENTRADA", registro.DataEntrada);
            comando.Parameters.AddWithValue("ADMINISTRADOR", registro.Administrador);
            comando.Parameters.AddWithValue("SALARIO", registro.Salario);
        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            Guid id = Guid.Parse(leitorRegistro["FUNCIONARIO_ID"].ToString());
            string nome = Convert.ToString(leitorRegistro["FUNCIONARIO_NOME"]);
            string login = Convert.ToString(leitorRegistro["FUNCIONARIO_LOGIN"]);
            string senha = Convert.ToString(leitorRegistro["FUNCIONARIO_SENHA"]);
            DateTime dataEntrada = Convert.ToDateTime(leitorRegistro["FUNCIONARIO_DATAENTRADA"]);
            bool administrador = Convert.ToBoolean(leitorRegistro["FUNCIONARIO_ADMINISTRADOR"]);
            decimal salario = Convert.ToDecimal(leitorRegistro["FUNCIONARIO_SALARIO"]);

            var funcionario = new Funcionario
            {
                Id = id,
                Nome = nome,
                Login = login,
                Senha = senha,
                DataEntrada = dataEntrada,
                Administrador = administrador,
                Salario = salario
            };

            return funcionario;
        }
    }
}
