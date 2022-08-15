using Locadora.Aplicacao.ModuloDevolucao;
using Locadora.Aplicacao.ModuloLocacao;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloDevolucao
{
    public class ControladorDevolucao : ControladorBase
    {
        private ServiceDevolucao serviceDevolucao;
        private ServiceLocacao serviceLocacao;
        TabelaDevolucaoControl TabelaDevolucao;

        public ControladorDevolucao(ServiceDevolucao serviceDevolucao, ServiceLocacao serviceLocacao)
        {
            this.serviceDevolucao=serviceDevolucao;
            this.serviceLocacao=serviceLocacao;
        }
        public override void Inserir()
        {
            var resultadoSelecaoLocacao = serviceLocacao.SelecionarTodos();
            var resultadoSelecaoDevolucao = serviceDevolucao.SelecionarTodos();

            if (resultadoSelecaoLocacao.Value.Count == 0)
            {
                MessageBox.Show("Nenhum Locação encontrada", "Seleção Locação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                

            TelaCadatroDevolucaoForm telaSelecaoDevolucao = new TelaCadatroDevolucaoForm("Inserir Devolução", "Inserir", resultadoSelecaoLocacao.Value);

            telaSelecaoDevolucao.GravarRegistro = serviceDevolucao.Inserir;

            if (telaSelecaoDevolucao.ShowDialog() == DialogResult.Cancel)
                return;

            CarregarLocacoes();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolboxDevolucao();
        }

        public override UserControl ObtemListagem()
        {
            if (TabelaDevolucao == null)
                TabelaDevolucao = new TabelaDevolucaoControl();

            CarregarLocacoes();

            return TabelaDevolucao;
        }
        private void CarregarLocacoes()
        {
            var resultado = serviceDevolucao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Devolucao> devolucoes = resultado.Value;

                TabelaDevolucao.AtualizarRegistros(devolucoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} Devoluções(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Devolução",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
