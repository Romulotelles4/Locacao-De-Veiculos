using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Locadora.Infra.Orm.Compartilhado
{
    public class LocadoraVeiculoDbContextFactory : IDesignTimeDbContextFactory<LocadoraVeiculoDbContext>
    {
        public LocadoraVeiculoDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            return new LocadoraVeiculoDbContext(connectionString);
        }
    }
}
