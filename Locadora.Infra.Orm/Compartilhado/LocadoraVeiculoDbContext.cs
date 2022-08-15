using Locadora.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Locadora.Infra.Orm.Compartilhado
{
    public class LocadoraVeiculoDbContext : DbContext, IContextoPersistencia
    {
        private string enderecoConexaoComBanco;

        public LocadoraVeiculoDbContext(string enderecoBanco)
        {
            enderecoConexaoComBanco = enderecoBanco;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(enderecoConexaoComBanco);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                //instalar o pacote Serilog.Extensions.Logging
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LocadoraVeiculoDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);


        }
    }
}
