using Locadora.Aplicacao.ModuloTaxa;
using Locadora.Apresentacao.WinForm.Compartilhado;
using Locadora.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        ServiceTaxa serviceTaxa;
        TabelaTaxaControl tabelaTaxa;

        public string MensagemErro { get; set; }

        public ControladorTaxa(ServiceTaxa serviceTaxa)
        {
            this.serviceTaxa=serviceTaxa;
        }

        public override void Editar()
        {

            var id = tabelaTaxa.ObtemNumeroMateriaSelecionado();

            if (id == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                 "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Taxa taxa = SelecionarTaxaPorNumero(id);

            if (taxa == null)
            {
                MessageBox.Show(MensagemErro,
                "Edição de taxa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TelaTaxa telaTaxa = new TelaTaxa("Editar Taxa", "Editar");

            telaTaxa.Taxa = taxa;
            telaTaxa.GravarRegistro = serviceTaxa.Editar;

            DialogResult dialogResult = telaTaxa.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            var id = tabelaTaxa.ObtemNumeroMateriaSelecionado();

            if (id == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                 "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Taxa taxa = SelecionarTaxaPorNumero(id);

            if (taxa == null)
            {
                MessageBox.Show(MensagemErro,
                "Exclusão de taxa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"Deseja realmente excluir a taxa '{taxa.Descricao}'?", "Exclusão de taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                return;

            var resultado = serviceTaxa.Excluir(taxa);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Exclusao de taxa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CarregarTaxas();
            }


        }

        public override void Inserir()
        {
            TelaTaxa telaTaxa = new TelaTaxa("Inserir Taxa", "Inserir");

            telaTaxa.Taxa= new Taxa();

            telaTaxa.GravarRegistro = serviceTaxa.Inserir;

            DialogResult resultado = telaTaxa.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override ConfigurarToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxa == null)
                tabelaTaxa = new TabelaTaxaControl();

            CarregarTaxas();

            return tabelaTaxa;
        }

        private void CarregarTaxas()
        {
            var resultado = serviceTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> grupos = serviceTaxa.SelecionarTodos().Value;

                tabelaTaxa.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} Taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Taxas",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Taxa SelecionarTaxaPorNumero(Guid guid)
        {
            var resultado = serviceTaxa.SelecionarPorId(guid);

            Taxa taxa = null;

            if (resultado.IsFailed)
            {
                MensagemErro = resultado.Errors[0].Message;
                return taxa;
            }

            taxa = resultado.Value;

            return taxa;

        }
    }
}
