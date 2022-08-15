using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Locadora.Test.Infra.Compartilhado
{
    public abstract class RepositorioBaseTest
    {
        //private string enderecoBanco =
        //    @"Data Source=(LOCALDB)\MSSQLLOCALDB;
        //      Initial Catalog=LocadoraVeiculosDBTest;
        //      Integrated Security=True";

        private string enderecoBanco;
        protected abstract string NomeTabela { get; }
        public RepositorioBaseTest()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            enderecoBanco = configuracao.GetConnectionString("SqlServer");

            LimparTabela("TBPLANOCOBRANCA");
            LimparTabela("TBVEICULO");
            LimparTabela("TBGRUPOVEICULO");
            LimparTabela("TBFUNCIONARIO");
            LimparTabela("TBCONDUTOR");
            LimparTabela("TBCLIENTE");
            LimparTabela("TBTAXA");
        }
        protected void LimparTabela(string tabela)
        {
            string sql;

            if (tabela == null)
                sql = @"DELETE FROM "+NomeTabela;
            else
                sql = $"DELETE FROM [{tabela}]";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();

            comando.ExecuteNonQuery();

            conexaoComBanco.Close();
        }
    }
}
