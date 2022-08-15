
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Locadora.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
        private static string enderecoBanco;

        public static void ExecutarSql(string sql)
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("ConfiguracaoAplicacao.json")
               .Build();

            enderecoBanco = configuracao.GetConnectionString("SqlServer");

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
