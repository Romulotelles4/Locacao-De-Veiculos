using Locadora.Apresentacao.WinForm.Compartilhado.ServiceLocator;
using Locadora.Infra.Logging;
using Locadora.Infra.Orm.Compartilhado;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm
{
    internal static class TelaPrincipal
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LocadoraVeiculosMigrador.AtualizarBancoDados();
            ConfiguracaoLogLocadora.ConfgurarLog();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var serviceLocatorAutofac = new ServiceLocatorAutofac();
            var serviceLocatorManual = new ServiceLocatorManual();
            Application.Run(new TelaPrincipalForm(serviceLocatorManual));
        }
    }
}
