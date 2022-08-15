using Locadora.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    public partial class TelaFiltroLocacaoForm : Form
    {
        public EnumLocacaoStatus statusLocacaoFiltro;
        public TelaFiltroLocacaoForm()
        {
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SetarFiltroSelecionado();
        }

        private void SetarFiltroSelecionado()
        {
            if (rBtnAbertas.Checked)
                statusLocacaoFiltro = EnumLocacaoStatus.Aberta;

            if (rBtnFinalizada.Checked)
                statusLocacaoFiltro = EnumLocacaoStatus.Finalizada;

            if (rBtnCanceladas.Checked)
                statusLocacaoFiltro = EnumLocacaoStatus.Cancelada;
        }
    }
}
