using Locadora.Aplicacao.ModuloGrupoDeVeiculos;
using Locadora.Aplicacao.ModuloVeiculo;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloCarro;
using Locadora.Dominio.ModuloGrupoDeVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        ServiceGrupoVeiculo serviceGrupoVeiculo;
        ServiceVeiculo serviceVeiculo;
        TabelaVeiculoControl tabelaVeiculo;
        List<GrupoVeiculo> grupoVeiculos;

        public ControladorVeiculo(ServiceGrupoVeiculo serviceGrupoVeiculo, ServiceVeiculo serviceVeiculo)
        {
            this.serviceGrupoVeiculo = serviceGrupoVeiculo;
            this.serviceVeiculo = serviceVeiculo;
        }

        public override void Editar()
        {
            var numero = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            if (numero == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                 "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculo = SelecionarVeiculoPorNumero(numero);

            if (veiculo == null)
            {
                MessageBox.Show("Falha no sistema ao selecionar um veiculo",
                "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultadoGrupoDeVeiculo = serviceGrupoVeiculo.SelecionarTodos();
            if (resultadoGrupoDeVeiculo.IsFailed)
            {
                MessageBox.Show("Falha no sistema ao selecionar um grupo de Veiculo",
                 "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TelaVeiculo telaVeiculo = new TelaVeiculo(resultadoGrupoDeVeiculo.Value, "Editar Veículo", "Editar");


            telaVeiculo.Veiculo = veiculo;
            telaVeiculo.GravarRegistro = serviceVeiculo.Editar;

            DialogResult dialogResult = telaVeiculo.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Excluir()
        {
            var numero = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            if (numero == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                 "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculo = SelecionarVeiculoPorNumero(numero);

            if (veiculo == null)
            {
                MessageBox.Show("Falha no sistema ao selecionar um veiculo",
                "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"Deseja realmente excluir o veiculo selecionado '{veiculo.Modelo}'?", "Exclusão de veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                return;

            var resultado = serviceVeiculo.Excluir(veiculo);

            if (resultado.IsSuccess)
                CarregarVeiculos();
            else
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



        }

        public override void Inserir()
        {
            var resultadoGrupoDeVeiculo = serviceGrupoVeiculo.SelecionarTodos();

            if (resultadoGrupoDeVeiculo.IsFailed)
            {
                MessageBox.Show("Falha no sistema ao selecionar um grupo de Veiculo",
                 "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            if (resultadoGrupoDeVeiculo.Value.Count == 0)
            {
                MessageBox.Show("Crie um grupo de Veiculo primeiro",
              "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            TelaVeiculo telaVeiculo = new TelaVeiculo(resultadoGrupoDeVeiculo.Value, "Inserir Veículo", "Inserir");

            telaVeiculo.Veiculo = new Veiculo();

            telaVeiculo.GravarRegistro = serviceVeiculo.Inserir;

            DialogResult resultado = telaVeiculo.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }


        }

        private void CarregarVeiculos()
        {
            var resultado = serviceVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} Veiculos");

                return;
            }

            MessageBox.Show("Falha ao selecionar todos os veiculos",
            "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {

            if (tabelaVeiculo == null)
                tabelaVeiculo = new TabelaVeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculo;
        }


        private Veiculo SelecionarVeiculoPorNumero(Guid guid)
        {
            var resultado = serviceVeiculo.SelecionarPorId(guid);

            Veiculo veiculo = null;

            if (resultado.IsFailed)
            {
                return veiculo;
            }

            veiculo = resultado.Value;

            return veiculo;

        }

    }
}
