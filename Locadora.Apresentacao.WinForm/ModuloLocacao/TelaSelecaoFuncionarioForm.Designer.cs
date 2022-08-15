namespace Locadora.Apresentacao.WinForm.ModuloLocacao
{
    partial class TelaSelecaoFuncionarioForm
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
            this.comboBoxFuncionarios = new System.Windows.Forms.ComboBox();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.linkLabelLimparSelecao = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFuncionarioSelecionado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionários";
            // 
            // comboBoxFuncionarios
            // 
            this.comboBoxFuncionarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncionarios.FormattingEnabled = true;
            this.comboBoxFuncionarios.Location = new System.Drawing.Point(12, 27);
            this.comboBoxFuncionarios.Name = "comboBoxFuncionarios";
            this.comboBoxFuncionarios.Size = new System.Drawing.Size(282, 23);
            this.comboBoxFuncionarios.TabIndex = 1;
            this.comboBoxFuncionarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxFuncionarios_SelectedIndexChanged);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(32, 118);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(90, 36);
            this.btnGravar.TabIndex = 2;
            this.btnGravar.Text = "Selecionar";
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(181, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // linkLabelLimparSelecao
            // 
            this.linkLabelLimparSelecao.AutoSize = true;
            this.linkLabelLimparSelecao.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabelLimparSelecao.Location = new System.Drawing.Point(208, 53);
            this.linkLabelLimparSelecao.Name = "linkLabelLimparSelecao";
            this.linkLabelLimparSelecao.Size = new System.Drawing.Size(86, 15);
            this.linkLabelLimparSelecao.TabIndex = 4;
            this.linkLabelLimparSelecao.TabStop = true;
            this.linkLabelLimparSelecao.Text = "Limpar seleção";
            this.linkLabelLimparSelecao.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLimparSelecao_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionário Selecionado";
            // 
            // lbFuncionarioSelecionado
            // 
            this.lbFuncionarioSelecionado.AutoSize = true;
            this.lbFuncionarioSelecionado.Location = new System.Drawing.Point(12, 82);
            this.lbFuncionarioSelecionado.Name = "lbFuncionarioSelecionado";
            this.lbFuncionarioSelecionado.Size = new System.Drawing.Size(144, 15);
            this.lbFuncionarioSelecionado.TabIndex = 6;
            this.lbFuncionarioSelecionado.Text = "[funcionario_selecionado]";
            // 
            // TelaSelecaoFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 167);
            this.Controls.Add(this.lbFuncionarioSelecionado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabelLimparSelecao);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.comboBoxFuncionarios);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(323, 206);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(323, 206);
            this.Name = "TelaSelecaoFuncionarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleção de Funcionário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFuncionarios;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel linkLabelLimparSelecao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFuncionarioSelecionado;
    }
}