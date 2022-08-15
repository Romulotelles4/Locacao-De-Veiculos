using Locadora.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace Locadora.Apresentacao.WinForm.Compartilhado
{
    public partial class TelaValidaPermissaoFuncionarioForm : Form
    {
        public TelaValidaPermissaoFuncionarioForm()
        {
            InitializeComponent();
        }

        public Func<IRepositorioFuncionario, bool> ValidaPermissao { get; set; }

        private void btnVerificar_Click(object sender, EventArgs e)
        {

        }
    }
}
