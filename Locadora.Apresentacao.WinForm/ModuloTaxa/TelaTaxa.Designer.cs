namespace Locadora.Apresentacao.WinForm.ModuloTaxa
{
    partial class TelaTaxa
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
            this.btnGravar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.txtBoxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Descrição = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkFixo = new System.Windows.Forms.RadioButton();
            this.checkDiario = new System.Windows.Forms.RadioButton();
            this.txtBoxValor = new System.Windows.Forms.TextBox();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(58, 307);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 32);
            this.btnGravar.TabIndex = 6;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(205, 307);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 32);
            this.BtnCancelar.TabIndex = 7;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtBoxDescricao
            // 
            this.txtBoxDescricao.Location = new System.Drawing.Point(28, 133);
            this.txtBoxDescricao.Name = "txtBoxDescricao";
            this.txtBoxDescricao.Size = new System.Drawing.Size(293, 23);
            this.txtBoxDescricao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Valor";
            // 
            // Descrição
            // 
            this.Descrição.AutoSize = true;
            this.Descrição.Location = new System.Drawing.Point(28, 115);
            this.Descrição.Name = "Descrição";
            this.Descrição.Size = new System.Drawing.Size(66, 15);
            this.Descrição.TabIndex = 7;
            this.Descrição.Text = "Descrição *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkFixo);
            this.groupBox1.Controls.Add(this.checkDiario);
            this.groupBox1.Location = new System.Drawing.Point(28, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de calculo";
            // 
            // checkFixo
            // 
            this.checkFixo.AutoSize = true;
            this.checkFixo.Location = new System.Drawing.Point(6, 47);
            this.checkFixo.Name = "checkFixo";
            this.checkFixo.Size = new System.Drawing.Size(90, 19);
            this.checkFixo.TabIndex = 5;
            this.checkFixo.Text = "Calculo Fixo";
            this.checkFixo.UseVisualStyleBackColor = true;
            // 
            // checkDiario
            // 
            this.checkDiario.AutoSize = true;
            this.checkDiario.Checked = true;
            this.checkDiario.Location = new System.Drawing.Point(6, 22);
            this.checkDiario.Name = "checkDiario";
            this.checkDiario.Size = new System.Drawing.Size(99, 19);
            this.checkDiario.TabIndex = 4;
            this.checkDiario.TabStop = true;
            this.checkDiario.Text = "Calculo Diario";
            this.checkDiario.UseVisualStyleBackColor = true;
            // 
            // txtBoxValor
            // 
            this.txtBoxValor.Location = new System.Drawing.Point(28, 81);
            this.txtBoxValor.Name = "txtBoxValor";
            this.txtBoxValor.Size = new System.Drawing.Size(86, 23);
            this.txtBoxValor.TabIndex = 1;
            this.txtBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxValor_KeyPress);
            // 
            // txtBoxId
            // 
            this.txtBoxId.Enabled = false;
            this.txtBoxId.Location = new System.Drawing.Point(28, 28);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(86, 23);
            this.txtBoxId.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID";
            // 
            // TelaTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 361);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxValor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Descrição);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxDescricao);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.btnGravar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(362, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(362, 400);
            this.Name = "TelaTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Taxa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox txtBoxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Descrição;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton checkFixo;
        private System.Windows.Forms.RadioButton checkDiario;
        private System.Windows.Forms.TextBox txtBoxValor;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label label2;
    }
}