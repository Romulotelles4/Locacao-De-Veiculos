using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace Locadora.Infra.Logging
{
    public static class ConfiguracaoLogLocadora
    {
        public static void ConfgurarLog()
        {

            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var diretorioSaida = configuracao.
                 GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File(diretorioSaida + "/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();
        }
    }
}
