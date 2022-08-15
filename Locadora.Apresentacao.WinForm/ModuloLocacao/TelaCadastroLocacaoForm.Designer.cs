namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxKmVeiculo = new System.Windows.Forms.TextBox();
            this.cBoxCliente = new System.Windows.Forms.ComboBox();
            this.cBoxGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxCondutor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelValorPrevisto = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.labelFuncionarioSelecionado = new System.Windows.Forms.Label();
            this.dateTimePickerLocacao = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // txtBoxKmVeiculo
            // 
            this.txtBoxKmVeiculo.Enabled = false;
            this.txtBoxKmVeiculo.Location = new System.Drawing.Point(264, 136);
            this.txtBoxKmVeiculo.Name = "txtBoxKmVeiculo";
            this.txtBoxKmVeiculo.Size = new System.Drawing.Size(215, 23);
            this.txtBoxKmVeiculo.TabIndex = 1;
            // 
            // cBoxCliente
            // 
            this.cBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCliente.FormattingEnabled = true;
            this.cBoxCliente.Location = new System.Drawing.Point(12, 47);
            this.cBoxCliente.Name = "cBoxCliente";
            this.cBoxCliente.Size = new System.Drawing.Size(215, 23);
            this.cBoxCliente.TabIndex = 2;
            this.cBoxCliente.SelectedIndexChanged += new System.EventHandler(this.cBoxCliente_SelectedIndexChanged);
            // 
            // cBoxGrupoVeiculo
            // 
            this.cBoxGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGrupoVeiculo.FormattingEnabled = true;
            this.cBoxGrupoVeiculo.Location = new System.Drawing.Point(12, 91);
            this.cBoxGrupoVeiculo.Name = "cBoxGrupoVeiculo";
            this.cBoxGrupoVeiculo.Size = new System.Drawing.Size(215, 23);
            this.cBoxGrupoVeiculo.TabIndex = 4;
            this.cBoxGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cBoxGrupoVeiculo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grupo de veículos";
            // 
            // cBoxPlanoCobranca
            // 
            this.cBoxPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPlanoCobranca.FormattingEnabled = true;
            this.cBoxPlanoCobranca.Location = new System.Drawing.Point(12, 136);
            this.cBoxPlanoCobranca.Name = "cBoxPlanoCobranca";
            this.cBoxPlanoCobranca.Size = new System.Drawing.Size(215, 23);
            this.cBoxPlanoCobranca.TabIndex = 6;
            this.cBoxPlanoCobranca.SelectedIndexChanged += new System.EventHandler(this.cBoxPlanoCobranca_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Plano de Cobrança";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data da Locação";
            // 
            // cBoxCondutor
            // 
            this.cBoxCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCondutor.FormattingEnabled = true;
            this.cBoxCondutor.Location = new System.Drawing.Point(264, 47);
            this.cBoxCondutor.Name = "cBoxCondutor";
            this.cBoxCondutor.Size = new System.Drawing.Size(215, 23);
            this.cBoxCondutor.TabIndex = 10;
            this.cBoxCondutor.SelectedIndexChanged += new System.EventHandler(this.cBoxCondutor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Condutor";
            // 
            // cBoxVeiculo
            // 
            this.cBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxVeiculo.FormattingEnabled = true;
            this.cBoxVeiculo.Location = new System.Drawing.Point(264, 91);
            this.cBoxVeiculo.Name = "cBoxVeiculo";
            this.cBoxVeiculo.Size = new System.Drawing.Size(215, 23);
            this.cBoxVeiculo.TabIndex = 12;
            this.cBoxVeiculo.SelectedIndexChanged += new System.EventHandler(this.cBoxVeiculo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Veículo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Km do veículo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data Devolução";
            // 
            // labelValorPrevisto
            // 
            this.labelValorPrevisto.AutoSize = true;
            this.labelValorPrevisto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelValorPrevisto.Location = new System.Drawing.Point(128, 374);
            this.labelValorPrevisto.Name = "labelValorPrevisto";
            this.labelValorPrevisto.Size = new System.Drawing.Size(94, 15);
            this.labelValorPrevisto.TabIndex = 17;
            this.labelValorPrevisto.Text = "[valor_previsto]";
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(87, 423);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 36);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "[label]";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(264, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 36);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelFuncionarioSelecionado
            // 
            this.labelFuncionarioSelecionado.AutoSize = true;
            this.labelFuncionarioSelecionado.Location = new System.Drawing.Point(12, 9);
            this.labelFuncionarioSelecionado.Name = "labelFuncionarioSelecionado";
            this.labelFuncionarioSelecionado.Size = new System.Drawing.Size(144, 15);
            this.labelFuncionarioSelecionado.TabIndex = 21;
            this.labelFuncionarioSelecionado.Text = "[funcionario_selecionado]";
            // 
            // dateTimePickerLocacao
            // 
            this.dateTimePickerLocacao.Location = new System.Drawing.Point(12, 180);
            this.dateTimePickerLocacao.Name = "dateTimePickerLocacao";
            this.dateTimePickerLocacao.Size = new System.Drawing.Size(215, 23);
            this.dateTimePickerLocacao.TabIndex = 22;
            // 
            // dateTimePickerDevolucao
            // 
            this.dateTimePickerDevolucao.Location = new System.Drawing.Point(264, 180);
            this.dateTimePickerDevolucao.Name = "dateTimePickerDevolucao";
            this.dateTimePickerDevolucao.Size = new System.Drawing.Size(215, 23);
            this.dateTimePickerDevolucao.TabIndex = 23;
            this.dateTimePickerDevolucao.ValueChanged += new System.EventHandler(this.dateTimePickerDevolucao_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(12, 374);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Valor total previsto:";
            // 
            // checkedBoxTaxas
            // 
            this.checkedBoxTaxas.FormattingEnabled = true;
            this.checkedBoxTaxas.Location = new System.Drawing.Point(12, 209);
            this.checkedBoxTaxas.Name = "checkedBoxTaxas";
            this.checkedBoxTaxas.Size = new System.Drawing.Size(467, 148);
            this.checkedBoxTaxas.TabIndex = 25;
            this.checkedBoxTaxas.SelectedIndexChanged += new System.EventHandler(this.checkedBoxTaxas_SelectedIndexChanged);
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 471);
            this.Controls.Add(this.checkedBoxTaxas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePickerDevolucao);
            this.Controls.Add(this.dateTimePickerLocacao);
            this.Controls.Add(this.labelFuncionarioSelecionado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.labelValorPrevisto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cBoxVeiculo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cBoxCondutor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cBoxPlanoCobranca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBoxGrupoVeiculo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxCliente);
            this.Controls.Add(this.txtBoxKmVeiculo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroLocacaoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxKmVeiculo;
        private System.Windows.Forms.ComboBox cBoxCliente;
        private System.Windows.Forms.ComboBox cBoxGrupoVeiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxPlanoCobranca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBoxCondutor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxVeiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelValorPrevisto;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label labelFuncionarioSelecionado;
        private System.Windows.Forms.DateTimePicker dateTimePickerLocacao;
        private System.Windows.Forms.DateTimePicker dateTimePickerDevolucao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedBoxTaxas;
    }
}