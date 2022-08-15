using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Locadora.Infra.Orm.Compartilhado
{
    public class LocadoraVeiculosMigrador
    {
        public static void AtualizarBancoDados()
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("ConfiguracaoAplicacao.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var db = new LocadoraVeiculoDbContext(connectionString);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
