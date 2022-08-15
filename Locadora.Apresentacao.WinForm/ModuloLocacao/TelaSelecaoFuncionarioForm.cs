using Locadora.Aplicacao.ModuloFuncionario;
using Locadora.Dominio.ModuloFuncionario;
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
    public partial class TelaSelecaoFuncionarioForm : Form
    {
        public List<Funcionario> Funcionarios { private get; set; }
        public Funcionario funcionarioSelecionado { get; private set; }
        public TelaSelecaoFuncionarioForm(List<Funcionario> funcionarios)
        {
            InitializeComponent();
            funcionarioSelecionado = new Funcionario();
            Funcionarios = funcionarios;
            ConfigurarFuncionarios();
            PreencherFuncionarioSelecionaro();
        }
        #region Métodos privados
        private void ConfigurarFuncionarios()
        {
            if (Funcionarios == null)
            {
                comboBoxFuncionarios.Items.Clear();

                comboBoxFuncionarios.Items.Add("Nenhum funcionário encontrado");

                return;
            }

            comboBoxFuncionarios.Items.Clear();

            comboBoxFuncionarios.Items.Add("Selecione");

            foreach (var item in Funcionarios)
                comboBoxFuncionarios.Items.Add(item);

            comboBoxFuncionarios.SelectedIndex = 0;
        }
        private void comboBoxFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFuncionarios.SelectedIndex == 0)
            {
                PreencherFuncionarioSelecionaro();
                return;
            }
                
            
            funcionarioSelecionado = (Funcionario)comboBoxFuncionarios.SelectedItem;

            lbFuncionarioSelecionado.Text =funcionarioSelecionado.Nome;
        }
        private void linkLabelLimparSelecao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigurarFuncionarios();
            PreencherFuncionarioSelecionaro();
        }
        private void PreencherFuncionarioSelecionaro()
        {
            if(funcionarioSelecionado != null && funcionarioSelecionado.Nome != null)
                lbFuncionarioSelecionado.Text = funcionarioSelecionado.Nome;

            lbFuncionarioSelecionado.Text = "Nenhum funcionário selecionado!";
        }
        #endregion
    }
}
